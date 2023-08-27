module crawler

open System.Net.Http
open System.IO
open System.Runtime.InteropServices.JavaScript
open System.Text.RegularExpressions

let downloadPageAsync (client: HttpClient) (url: string) =
    client.GetStringAsync(url) |> Async.AwaitTask |> Async.Catch

let patternMatch html =
    match html with
    | Some html ->
        let pattern = Regex("<a .*?href=\"(https?://\S*)\".*?>", RegexOptions.Compiled)
        pattern.Matches(html) |> Seq.map (fun m -> m.Groups[1].Value)
    | None -> Seq.empty
    
let getLengthsAsync (client: HttpClient) (url: string) =
    async {
        let! initialPage  = downloadPageAsync client url

        match initialPage with
        | Choice1Of2 str ->
            let urls = patternMatch (Some str)
            let! pages = urls |> Seq.map (downloadPageAsync client) |> Async.Parallel

            return
                pages
                |> Seq.map (fun page ->
                    match page with
                    | Choice1Of2 str -> str |> String.length |> Some
                    | Choice2Of2 _ -> None)
                |> Seq.zip urls
        | Choice2Of2 ex ->
            do printfn $"{ex.Message}"
            return Seq.empty
    }

let crawl (url:string) =
    async {
        let client = new HttpClient()
        let! stats = getLengthsAsync client url

        stats
        |> Seq.iter (fun (url, length) ->
            match length with
            | Some l -> printfn $"{url} - {l}"
            | None -> printfn $"{url} - the connection cannot be established")
    }
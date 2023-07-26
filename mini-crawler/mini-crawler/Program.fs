module crawler

open System.Net.Http
open System.IO
open System.Text.RegularExpressions

let downloadPageAsync (url:string) =
    async {
       try
            use client = new HttpClient()
            use! stream = client.GetStreamAsync(url) |> Async.AwaitTask
            use reader = new StreamReader(stream)
            let html = reader.ReadToEnd()
            do printf $"%s{url} is %d{html.Length} characters length\n"
            return html
       with
            ex ->
                printfn "%s" ex.Message
                return ""
    }

let patternMatch html =
    let pattern = Regex("<a .*?href=\"(https?://\S*)\".*?>", RegexOptions.Compiled)
    let matches = pattern.Matches(html) |> Seq.map (fun m -> m.Groups[1].Value)
    matches
    
let getUrlsAsync (url:string) =
    async {
       let! html = downloadPageAsync url
       let matches = patternMatch html
       return matches
    }

let crawl url = getUrlsAsync(url)
                |> Async.RunSynchronously
                |> Seq.map downloadPageAsync
                |> Async.Parallel
                |> Async.Ignore
                |> Async.RunSynchronously
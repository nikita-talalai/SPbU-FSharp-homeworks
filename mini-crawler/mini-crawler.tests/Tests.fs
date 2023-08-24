module tests

open NUnit.Framework
open FsUnit
open crawler

[<Test>]
let ``Empty input`` () =
    None
    |> patternMatch
    |> should equalSeq
            Seq.empty

[<Test>]
let ``Simple <a> tag`` () =
    Some "<a href=\"https://www.youtube.com/watch?v=dQw4w9WgXcQ\">"
    |> patternMatch
    |> should equalSeq
           (seq{"https://www.youtube.com/watch?v=dQw4w9WgXcQ"})
    
[<Test>]
let ``<a> tag with attributes`` () =
    Some "<a href=\"https://www.youtube.com/watch?v=dQw4w9WgXcQ\" title=\"Rick-roll :)\">"
    |> patternMatch
    |> should equalSeq
           (seq{"https://www.youtube.com/watch?v=dQw4w9WgXcQ"})
    
[<Test>]
let ``Random text without urls`` () =
    let content = Some "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
    content
    |> patternMatch
    |> should equalSeq Seq.empty

[<Test>]
let ``Random text with several urls`` () =
    let content = Some "<a href=\"https://market.yandex.ru/\" > <a href=\"https://www.ozon.ru/\" > https://www.avito.ru/>"
    content
    |> patternMatch
    |> should equalSeq (seq{"https://market.yandex.ru/"; "https://www.ozon.ru/"})
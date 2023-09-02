module PhoneBook

open System.IO

type PhoneRecord = { Name:string; Phone:int }

let FindPhone book name =
    try
        List.find (fun record -> record.Name = name) book
        |> (fun record -> Some record.Phone)
    with _ -> None
let FindName book phone =
    try
        List.find (fun record -> record.Phone = phone) book
        |> (fun record -> Some record.Name)
    with _ -> None
let AddRecord book record =
    if (book, record.Name) ||> FindPhone = None
        && (book, record.Phone) ||> FindName = None
    then record::book
    else book
    
let PrintBook book =
    book
    |> Seq.iter (fun record -> printfn $"{record.Name} {record.Phone}")
    
let SaveBook (path:string) book =
    try
        use writer = new StreamWriter(path)
        book
        |> List.iter (fun record -> writer.WriteLine $"{record.Name} {record.Phone}")
    with ex ->
        printfn $"{ex.Message}"
let ReadBook (path: string) =
    let lines = File.ReadAllLines(path)
    lines
    |> Array.map (fun str -> str.Split " ")
    |> Array.map (fun str -> {Name=str|>Array.head; Phone=str|>Array.last|>int})
    |> Array.toList
        
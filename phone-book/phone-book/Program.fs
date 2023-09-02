module Program

open System
open System.IO
open PhoneBook

let PrintMenu () =
    "Commands:\n\
    1. Print book\n\
    2. Add record\n\
    3. Find phone\n\
    4. Find name\n\
    5. Save book\n\
    6. Read book\n\
    7. Clear book\n\
    8. Exit\n"
    |> printfn "%s"

let GetName () =
    printf "%s" "Enter name: "
    Console.ReadLine()

let rec GetPhone () =
    printf "%s" "Enter phone: "
    try
        Console.ReadLine() |> int
    with
    | :? FormatException ->
        Console.WriteLine "Incorrect format"
        GetPhone ()

let rec GetPath () =
    printf "%s" "Enter path: "
    let path = Console.ReadLine()
    if File.Exists path then path
    else
        printfn "%s" "File doesn't exist"
        GetPath ()

let rec exec book =
    printf "%s" "Enter command: "
    match Console.ReadLine() with
    | "1" ->
        book |> PrintBook
        book |> exec
    | "2" -> (book, {Name=GetName(); Phone=GetPhone()}) ||> AddRecord |> exec
    | "3" ->
        (book, GetName()) ||> FindPhone |> printfn "%A"
        book |> exec
    | "4" ->
        (book, GetPhone()) ||> FindName |> printfn "%A"
        book |> exec
    | "5" ->
        (GetPath(), book) ||> SaveBook
        book |> exec
    | "6" ->
        GetPath() |> ReadBook |> exec
    | "7" -> [] |> exec
    | "8" -> ignore ()
    | _ ->
        PrintMenu ()
        book |> exec

PrintMenu ()
exec []

module task.Program
open System

type AddingStringsBuilder() =
    member this.Bind(x:string, f) =
        try 
            x |> int |> f
        with :? FormatException -> 
            None
    member this.Return(x) =
        Some x
        
type RoundingBuilder(accuracy : int) =
    member this.Bind(x:float, f) =
        Math.Round(x, accuracy) |> f
    member this.Return(x:float) =
        Math.Round(x, accuracy)
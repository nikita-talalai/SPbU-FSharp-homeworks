module task.Tests

open NUnit.Framework
open FsUnit
open task.Program

[<Test>]
let ``Rounding with accuracy 3`` () =
    let rounding = RoundingBuilder(3)
    
    let res = rounding {
        let! a = 2.0 / 12.0
        let! b = 3.5
        return a / b
    }
    
    res |> should equal 0.048

[<Test>]
let ``Rounding with accuracy 0`` () =
    let rounding = RoundingBuilder(0)
    
    let res = rounding {
        let! a = 2.0 / 12.0
        let! b = 3.5
        return a / b
    }
    
    res |> should equal 0
    
[<Test>]
let ``Rounding with negative accuracy`` () =
    (fun () ->
        let rounding = RoundingBuilder(-1)
        
        rounding {
        let! a = 2.0 / 12.0
        let! b = 3.5
        return a / b
        } |> ignore)
    |>  should throw typeof<System.ArgumentOutOfRangeException>
    
let ``Rounding with big accuracy`` () =
    (fun () ->
        let rounding = RoundingBuilder(20)
        
        rounding {
        let! a = 2.0 / 12.0
        let! b = 3.5
        return a / b
        } |> ignore)
    |>  should throw typeof<System.ArgumentOutOfRangeException>
    
[<Test>]
let ``Strings with correct int32 format`` () =
    let adding = AddingStringsBuilder()
    
    let res = adding {
        let! x = "1"
        let! y = "2"
        let z = x + y
        return z
    }
    
    res |> should equal (Some 3)

[<Test>]
let ``Strings with incorrect int32 format`` () =
    let adding = AddingStringsBuilder()
    
    let res = adding {
        let! x = "1"
        let! y = "a"
        let z = x + y
        return z
    }
    
    res |> should equal None
    
[<Test>]
let ``Empty strings`` () =
    let adding = AddingStringsBuilder()
    
    let res = adding {
        let! x = ""
        let! y = ""
        let z = x + y
        return z
    }
    
    res |> should equal None
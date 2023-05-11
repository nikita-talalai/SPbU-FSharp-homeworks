module test.Tests

open NUnit.Framework
open FsUnit
open test.Program

[<Test>]
let ``Supermap with single output (like a usual map)`` () =
    [1; 2; 3] |> supermap (fun x -> [(*) 2 x]) |> should equal [2; 4; 6]
    
[<Test>]
let ``Supermap with several outputs`` () =
    [1; 2; 3] |> supermap (fun x -> [ (*)2 x; (*)3 x]) |> should equal [2; 3; 4; 6; 6; 9]

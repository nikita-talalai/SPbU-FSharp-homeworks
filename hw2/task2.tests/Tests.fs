module task2.Tests

open NUnit.Framework
open FsUnit
open task2.Program

[<Test>]
let ``Empty tree`` () =
    mapTree id Empty |> should equal Empty
    
[<Test>]
let ``Mapping not empty tree`` () =
    let input = Node(1, Node(2, Empty, Empty), Node(3, Empty, Empty))
    let expected = Node(2, Node(4, Empty, Empty), Node(6, Empty, Empty))
    
    ((*) 2, input) ||> mapTree |> should equal expected

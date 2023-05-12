module retest.Tests

open NUnit.Framework
open FsUnit
open retest.task1
open retest.task2

[<Test>]
let ``Return all elements of tree`` () =
    let BinTree = Node('h', Node('e', Node('l', Empty, Empty), Node('l', Empty, Empty)), Node('o', Empty, Empty))
    BinTree |> filter (fun x -> true) |> should equivalent ['h'; 'e'; 'l'; 'l'; 'o']
    
[<Test>]
let ``Return all non-zero numbers`` () =
    let BinTree = Node(1, Node(0, Node(3, Empty, Empty), Node(0, Empty, Empty)), Node(0, Empty, Empty))
    BinTree |> filter (fun x -> x <> 0) |> should equivalent [1; 3]
    
[<Test>]
let ``Empty tree`` () =
    Empty |> filter (fun x -> true) |> should equal []
    
[<Test>]
let ``First 10 elements of sequence`` () =
    init_seq() |> Seq.take 10 |> should equal [1; 2; 2; 3; 3; 3; 4; 4; 4; 4]
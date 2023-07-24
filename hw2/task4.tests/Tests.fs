module task4.Tests

open task4.Program
open NUnit.Framework
open FsUnit

[<Test>]
let ``isPrime works correct`` () =
    seq{-2; -1; 0; 1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12; 13; 14; 15; 16; 17; 18; 19; 20; 23; 24; 25; 26; 27; 28; 29}
    |> Seq.filter isPrime |> should equal <| seq{2; 3; 5; 7; 11; 13; 17; 19; 23; 29}
        
[<Test>]
let ``Expected generation`` () =
    primeGenerator() |> Seq.skip 10 |> Seq.take 10 |> should equalSeq <| seq {31; 37; 41; 43; 47; 53; 59; 61; 67; 71}

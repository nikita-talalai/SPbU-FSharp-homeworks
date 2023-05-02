module task4.Tests

open task4.Program
open NUnit.Framework
open FsUnit
open FsCheck

[<Test>]
let ``Negative numbers are not prime`` () =
    seq{-10 .. -1} |> Seq.forall (isPrime >> not) |> should equal true

[<Test>]
let ``Edge cases are correct`` () =
    (isPrime 0 && isPrime 1) |> should equal false

[<Test>]
let ``isPrime works correct for prime numbers`` () =
    seq{2; 3; 5; 7; 11; 13; 17; 19; 23; 29} |> Seq.forall isPrime |> should equal true
        
[<Test>]
let ``Expected generation`` () =
    primeGenerator() |> Seq.skip 10 |> Seq.take 10 |> should equalSeq <| seq {31; 37; 41; 43; 47; 53; 59; 61; 67; 71}

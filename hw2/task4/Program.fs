module task4.Program
let isPrime n =
    match n with
    | n when n <= 1 -> false
    | n when n = 2 -> true
    | n ->
        2 :: [3 .. 2 .. (n |> float |> sqrt |> int) + 1]
        |> List.filter (fun x -> n % x = 0)
        |> List.isEmpty 
let primeGenerator () =
    (+) 2 |> Seq.initInfinite |> Seq.filter isPrime
module task4.Program
let rec isPrime n =
    match n with
    | n when n <= 1 -> false
    | n when n = 2 -> true
    | n when n % 2 = 0 -> false
    | n ->
         let rec  loop n m =
            if m > (n |> float |> sqrt |> int) + 1 then true
            elif n % m = 0 then false
            else loop n (m + 2)
         loop n 3
         
let primeGenerator () =
    (+) 2 |> Seq.initInfinite |> Seq.filter isPrime
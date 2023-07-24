let fibonacchi n =                      // fibonacchi sequence: 1, 1, 2, 3, 5, 8, ...
    match n with                        //             indexes: 1, 2, 3, 4, 5, 6
    | 0u -> None
    | 1u | 2u -> Some 1I
    | _ -> 
        let rec loop iter fst snd =
            match n - iter with
            | 0u -> Some snd
            | _ -> loop (iter + 1u) snd (fst + snd)
        loop 2u 1I 1I
        
printf "%A" <| fibonacchi 100u
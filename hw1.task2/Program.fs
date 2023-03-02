let fibbonachi n =
    match n with
    | 0u -> None
    | 1u -> Some 1I
    | 2u -> Some 1I
    | _ -> 
        let rec loop iter fst snd =
            match n - iter with
            | 0u -> Some snd
            | _ -> loop (iter + 1u) snd (fst + snd)
        loop 2u 1I 1I
        
printf "%A" <| fibbonachi 100u
let factorial n =
    let rec loop n acc = 
        match n with
        | 0u -> acc
        | n -> loop (n-1u) (acc*bigint(n))
    loop n 1I

printf "%A" <| factorial 100u
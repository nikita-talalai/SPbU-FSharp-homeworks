let func n m =                    // length of list: (n + m) - n + 1 = m + 1
    if n < 0 || m <= -1 then []
    else
        let fst = pown 2 n
        let rec loop fst iter acc =
            if iter = m + 1 then []
            else fst :: loop (fst * 2) (iter + 1) acc
        loop fst 0 []
    
printf "%A" <| func 3 2
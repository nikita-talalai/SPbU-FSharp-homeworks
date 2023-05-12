module retest.task1

let init_seq ()=
    let rec calc n =
        let rec rec_calc n m =
            if n - m <= 0 then m
            else rec_calc (n - m) (m + 1)
        rec_calc n 0
    
    Seq.initInfinite calc
    
init_seq () |> Seq.take 100 |> Seq.iter (printf "%i ")
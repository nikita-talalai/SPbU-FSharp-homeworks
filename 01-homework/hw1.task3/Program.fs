﻿let reverse aList = 
    let rec loop aList acc =
        match aList with
        | [] -> acc
        | h :: t -> loop t (h :: acc)
    loop aList []

printf "%A" <| reverse [1..5]
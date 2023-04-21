// Task 1: Supermap

let supermap aList func =
    let rec rec_map aList func acc =
        match aList with
        | [] -> acc
        | h :: t -> rec_map t func (func h :: acc)
    rec_map aList func []
    
printfn "%A" <| supermap [1.0 ; 2.0 ; 3.0] (fun x -> [sin x ; cos x])


// Task 2: Diamond
let diamond n =
    match n with
    | 0 -> []
    | n -> [1 ..  2 .. (n * 2) - 1] @ [(n * 2) - 1 ..  -2 .. 1]
let multiply text times = String.replicate times text
let result n = List.map (fun n -> multiply "*"  n) (diamond n)
printfn "%A" <| result 4




module test.Program
// Task 1: Supermap

let supermap mapping list =
    let rec map mapping list acc =
        match list with
        | [] -> acc
        | h :: t -> map mapping t (List.append acc (mapping h))
    map mapping list []

// Task 2: Diamond

let diamond n =
    let calc_body = function
    | 0 -> []
    | n -> [1 ..  2 .. (n * 2) - 3] @ [(n * 2) - 1] @ [(n * 2) - 3 ..  -2 .. 1]
    
    let calc_indentations = function
    | 0 -> []
    | n -> [n - 1 .. -1 .. 1] @ [0] @ [1 .. n - 1]
    
    let multiply text times = String.replicate times text
    
    let body n = List.map (fun n -> multiply "*"  n) (calc_body n)
    let indentations n = List.map (fun n -> multiply " " n) (calc_indentations n)
    
    List.iter2 (printfn "%s%s") (n |> indentations) (n |> body)
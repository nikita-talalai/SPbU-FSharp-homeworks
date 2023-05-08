module task3.Program

type Expression =
    | Const of int
    | Plus of Expression * Expression
    | Minus of Expression * Expression
    | Times of Expression * Expression
    | Divide of Expression * Expression

let calculate exp =
    let rec calcCPS exp cont =
        match exp with 
        | Const(x) -> cont x
        | Plus(x, y) -> calcCPS x (fun x -> calcCPS y (fun y -> cont (x + y)))
        | Minus(x, y) -> calcCPS x (fun x -> calcCPS y (fun y -> cont (x - y)))
        | Times(x, y) -> calcCPS x (fun x -> calcCPS y (fun y -> cont (x * y)))
        | Divide(x, y) ->
            match calcCPS y Some with 
            | Some 0 -> None 
            | Some(y) -> calcCPS x (fun x -> cont (x / y))
            | None -> None
            
    calcCPS exp Some 
    
    // calcCPS (2 + 3) id
    // calcCPS 2 (fun x -> calcCPS 3 (fun y -> id (x + y)))
    // (fun x -> calcCPS 3 (fun y -> id (x + y)) 2
    // calcCPS 3 (fun y -> id (2 + y))
    // (fun y -> id (2 + y)) 3
    // id (2 + 3)
    // Some 5
    // calcCPS (2 / 0) id
    // calcCPS 0 id
    // (fun x -> calcCPS 3 (fun y -> id (x + y)) 0
    // calcCPS 3 (fun y -> id (2 + y))
    // (fun y -> id (2 + y)) 3
    // id (2 + 3)
    // 5 
    
let exp = Plus(Minus(Const(10), Const(3)), Times(Minus(Const(7), Const(1)), Const(4))) // (10 - 3) + (7 - 1) * 4
printfn "%A" <| calculate exp
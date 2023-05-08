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
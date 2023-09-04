module lambda
open System

type Var = string
type Term =
    | Var of Var
    | Application of Term * Term
    | Abstraction of Var * Term

let getNewName usedVars =
    let max: string = Set.maxElement usedVars
    let last = Seq.last max

    match Char.IsDigit last with
    | true ->
        max[0 .. max.Length - 2]
        + (last |> Char.GetNumericValue |> int |> (+) 1 |> string)
    | false -> max[0 .. max.Length - 1] + "0"
    
let rec getFreeVars term =
    match term with
    | Var x -> Set.singleton x
    | Application (term1, term2) -> Set.union (getFreeVars term1) (getFreeVars term2)
    | Abstraction (x, term) -> Set.difference (getFreeVars term) (x |> Var |> getFreeVars)

let rec substitution var term1 term2 =
    
    let IsConflict var term2 = Set.contains var (getFreeVars term2)
    
    match (term1, term2) with
    | Var x, term2 when x = var -> term2
    | Var x, term2 when x <> var -> Var x
    | Application (leftTerm, rightTerm), term2 ->
        Application (substitution var leftTerm term2, substitution var rightTerm term2)
    | Abstraction (x, term), Var z when var = z -> Abstraction (x, term)
    | Abstraction (x, term), term2 when IsConflict x term2 = false ->
        Abstraction (x, substitution var term term2)
    | Abstraction (x, term), term2 when IsConflict x term2 = true ->
        let newVar = (getFreeVars term, getFreeVars term2) ||> Set.union |> getNewName
        let x = newVar |> Var |> substitution var term
        let newTerm = substitution var x term2
        Abstraction (newVar, newTerm)

let rec betaReduction term =
    match term with
    | Application (term1, term2) ->
        let newTerm = betaReduction term1
        match newTerm with
        | Abstraction(x, term) -> substitution x term term2 |> betaReduction
        |_ -> Application(newTerm, betaReduction term2)
    | Abstraction(x, term) -> Abstraction(x, betaReduction term)
    | Var x -> Var x
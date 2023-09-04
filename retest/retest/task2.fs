module retest.task2

type BinTree<'a> =
    | Node of 'a * BinTree<'a> * BinTree<'a>
    | Empty
    
type ContinuationStep<'a> =
    | Finished
    | Step of 'a * (unit -> ContinuationStep<'a>)
    
let rec traverse tree cont =
    match tree with
    | Node(x, l, r) -> Step(x, (fun () -> traverse l (fun () -> traverse r cont)))
    | Empty -> cont()

let filter predicate tree =
    let steps = traverse tree (fun () -> Finished)
        
    let rec processSteps step acc =    
        match step with
        | Step(x, getNext) ->
            if predicate x then processSteps (getNext()) (x :: acc)
            else processSteps (getNext()) acc
        | Finished -> acc
    processSteps steps []
module task2.Program

type BinTree<'a> =
    | Node of 'a * BinTree<'a> * BinTree<'a>
    | Empty
    
let mapTree mapping tree =
    let rec innerMap tree cont =
        match tree with
        | Node(x, l, r) ->
            innerMap l (fun left -> innerMap r (fun right -> cont (Node(mapping x, left, right))))
        | Empty -> cont Empty
    innerMap tree id
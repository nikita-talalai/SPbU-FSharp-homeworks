module hw2.Program
    let quantity_mod1 aList = aList |> List.map (fun x -> if x % 2 = 0 then 1 else 0 ) |> List.fold (+) 0
    let quantity_mod2 aList = aList |> List.filter (fun x -> x % 2 = 0) |> List.length
    let quantity_mod3 = List.filter (fun x -> x % 2 = 0) >> List.length

    open FsCheck
    let mod1_Is_mod2 (aList:list<int>) = quantity_mod1 aList = quantity_mod2 aList
    Check.Quick mod1_Is_mod2
    let mod1_Is_mod3 (aList:list<int>) = quantity_mod1 aList = quantity_mod3 aList
    Check.Quick mod1_Is_mod3
    let mod2_Is_mod3 (aList:list<int>) = quantity_mod2 aList = quantity_mod3 aList
    Check.Quick mod2_Is_mod3
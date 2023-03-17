module hw2.Tests
    
    open hw2.Program
    open NUnit.Framework
    open FsUnit
    
    [<Test>]
    let ``Empty list`` () =
        quantity_mod1 [1] |> should equal 0
        
    [<Test>] 
    let ``Only even numbers`` () =
        quantity_mod1 [for i in 1 .. 10 -> 2*i] |> should equal 10
 
    [<Test>]    
    let ``Only odd numbers`` () =
        quantity_mod1 [1 .. 2 .. 5] |> should equal 0
     
    [<Test>]   
    let ``Regular test`` () =
        quantity_mod1 [1 .. 10] |> should equal 5
    




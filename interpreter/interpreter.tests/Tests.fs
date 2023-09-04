module interpreter.tests

    open NUnit.Framework
    open FsUnit
    open lambda

    [<Test>]
    let ``Test normal strategy`` () =
        let value =
            Application(
                        Abstraction("x", Var "y"),
                        Application(
                            Abstraction("x", Application(Var "x", Var "x")),
                            Abstraction("x", Application(Var "x", Var "x"))))
        
        value |> betaReduction |> should equal (Var "y")

    [<Test>]    
    let ``Test on variable`` () =
        let value = Var "x"
            
        value |> betaReduction |> should equal (Var "x")
        
    [<Test>]
    let ``Test on lambda abstraction`` () =
        let value = Abstraction("x", Var "y")

        value |> betaReduction |> should equal (Abstraction("x", Var "y"))
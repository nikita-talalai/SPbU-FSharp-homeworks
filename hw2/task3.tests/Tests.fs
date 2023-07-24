module task3.Tests

open NUnit.Framework
open FsUnit
open FsCheck
open task3.Program

[<Test>]
let ``Addition works correct`` () =
   Plus(Const(1), Const(1)) |> calculate |> should equal (Some 2)
   
[<Test>]
let ``Subtraction works correct`` () =
   Minus(Const(5), Const(2)) |> calculate |> should equal (Some 3)
   
[<Test>]
let ``Multiplication works correct`` () =
   Times(Const(2), Const(2)) |> calculate |> should equal (Some 4)
   
[<Test>]
let ``Division works correct`` () =
   Divide(Const(10), Const(2)) |> calculate |> should equal (Some 5)

[<Test>]
let ``Division by 0 should return None`` () =
   Divide(Const(1), Const(0)) |> calculate |> should equal None
   
[<Test>]
let ``Addition is commutative`` () =
   let plustest l r = calculate(Plus(Const(l), Const(r))) = calculate(Plus(Const(r), Const(l)))

   Check.QuickThrowOnFailure plustest

[<Test>]
let ``Multiplication is commutative`` () =
   let timestest l r = calculate(Times(Const(l), Const(r))) = calculate(Times(Const(r), Const(l)))

   Check.QuickThrowOnFailure timestest
   
[<Test>]
let ``Addition is associative`` () =
   let plustest a b c = calculate(Plus(Plus(Const(a), Const(b)), Const(c))) = calculate(Plus(Const(a), Plus(Const(b), Const(c))))
   
   Check.QuickThrowOnFailure plustest
   
[<Test>]
let ``Multiplication is associative`` () =
   let timestest a b c = calculate(Times(Times(Const(a), Const(b)), Const(c))) = calculate(Times(Const(a), Times(Const(b), Const(c))))

   Check.QuickThrowOnFailure timestest
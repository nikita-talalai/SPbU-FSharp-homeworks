module bracket_sequence.Tests

open NUnit.Framework
open FsUnit
open bracket_sequence.Program

[<Test>]
let ``Simple cases`` () =
    (check "()" && check "[]" && check "{}") |> should equal true
    
[<Test>]
let ``String with a lot kind of cases which has a correct bracket sequence`` () =
    check "()()[][]{}{}({[]})(()){{}}[[]]" |> should equal true
    
[<Test>]
let ``String with a lot kind of cases which has a incorrect bracket sequence`` () =
    check "][(){]()[[[]]]{)(}" |> should equal false
    
[<Test>]
let ``Equal quantity of brackets but in incorrect order `` () =
    (check ")(" || check "][][" || check "}}{{") |> should equal false
    
[<Test>]
let ``Equal quantity of open and close brackets (but different type) is not correct bracket sequence `` () =
    (check "(]" || check "(}" ||
     check "[)" || check "[}" ||
     check "{)" || check "{]") |> should equal false
    
[<Test>]
let ``String, which has not any brackets, has a correct bracket sequence `` () =
    check "hello, world!" |> should equal true
    
[<Test>]
let ``Empty string has a correct bracket sequence`` () =
    check "" |> should equal true    
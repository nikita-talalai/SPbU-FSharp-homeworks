﻿let func x l = List.map (fun y -> y * x) l
let func' x = List.map (fun y -> y * x)
let func'' x = List.map ((*) x)
let func''' = List.map << (*)

open FsCheck

let functionsAreEquivalent x l = func''' x l = func x l
Check.QuickThrowOnFailure functionsAreEquivalent

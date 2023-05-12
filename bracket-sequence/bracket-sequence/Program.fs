module bracket_sequence.Program
 
let check str =
    let innerCheck (symbols : string)  =
        let rec processStr (str : string) i count =
            if i = str.Length || count < 0 then count = 0
            else
                match str[i] with
                | _ when str[i] = symbols[0] -> processStr str (i + 1) (count + 1)
                | _ when str[i] = symbols[1] -> processStr str (i + 1) (count - 1)
                | _ -> processStr str (i + 1) count
        processStr str 0 0 
    innerCheck "()" && innerCheck "[]" && innerCheck "{}"
    
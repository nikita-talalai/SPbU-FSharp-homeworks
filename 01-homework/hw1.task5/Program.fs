let find_n aList n =
  if aList = [] then None
  else   
    let rec loop aList n iter =
      if List.head aList = n then Some iter
      elif iter = List.length aList then None
      else loop (List.tail aList) n (iter+1)
    loop aList n 0 
 
printfn "%A" <| find_n [1; 2] 3
printfn "%A" <| find_n [1; 3; 2; 3] 3
printfn "%A" <| find_n [] 3
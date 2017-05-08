// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System
open ConnectFour

//can run these in F# interactive window by either
// isOdd (square 12);;
//or
// 12 |> square |> isOdd;;
let square x = x * x

let isOdd x = x % 2 <> 0

let rec fibonacci n =
    if n = 0 then 1
    elif n = 1 then 1
    else fibonacci (n-1) + fibonacci (n-2)

[<EntryPoint>]
let main argv = 
    printfn "%d square is %d" 12 (square 12)
    printfn "fibonacci of %d is %d" 5 (fibonacci 5)

    Console.ReadKey() |> ignore

    ConnectFour.printGame |> ignore

    Console.ReadKey() |> ignore
    0 // return an integer exit code

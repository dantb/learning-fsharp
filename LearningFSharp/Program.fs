// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

module HelloSquare

let square x = x * x
let isOdd x = x % 2 <> 0

[<EntryPoint>]
let main argv = 
    printfn "%d square is %d" 12 (square 12)
    0 // return an integer exit code

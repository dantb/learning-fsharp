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
 
let readLine() =
    try
        Console.ReadLine() |> int
    with
    | :? System.FormatException ->
        -1
 
[<EntryPoint>]
let main argv =
//    printfn "%d square is %d" 12 (square 12)
//    printfn "fibonacci of %d is %d" 5 (fibonacci 5)
 
    Console.ReadKey() |> ignore 
 
    let invalidInput col =
        col < 0 or col > 6
  
    let rec getInput invalid col =
        if invalid then           
            Console.Write("Enter a column between 0 and 6 inclusive in which to drop your piece: ")
            let col = readLine()
            getInput (invalidInput col) col
        else
            col
 
    let game = new ConnectFour.Game()
    //yellow goes first
    game.setCurrentPlayer ConnectFour.getYellow
    ConnectFour.printGame game
 
    let noWinner = false
    //game loop
    while game.getWinner = ConnectFour.Empty do
        if game.getCurrentPlayer = ConnectFour.getRed then
            printf "Red's turn\n"
        else printf "Yellow's turn\n"
        let col = getInput true -1
 
        let otherPlayer (colour:ConnectFour.Node) =
            if colour = ConnectFour.getRed then ConnectFour.getYellow
            else ConnectFour.getRed
 
        let dropPieceColour (colour:ConnectFour.Node) =
            let g = ConnectFour.dropPiece game colour col
            game.setArray g.getArray
            game.setWinner g.getWinner
            game.setCurrentPlayer (otherPlayer game.getCurrentPlayer)
 
        if game.getCurrentPlayer = ConnectFour.getRed then
            dropPieceColour ConnectFour.getRed
        elif game.getCurrentPlayer = ConnectFour.getYellow then
            dropPieceColour ConnectFour.getYellow
 
        ConnectFour.printGame game
 
 
    Console.ReadKey() |> ignore
    0 // return an integer exit code
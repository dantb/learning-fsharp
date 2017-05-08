namespace ConnectFour

open System

module ConnectFour =

    type Node =
        | Red
        | Yellow
        | Empty

    let getRed = Red

    let getYellow = Yellow
        
    type Game() =
        let game = Array2D.init<Node> 6 7 (fun x y -> Empty) 

        member this.getNode row col =
            game.[row, col]

        member this.setNode (piece:Node) row col =
            game.[row, col] <- piece

    let getNodeString (g:Game) row col =
        let nodeString =
            match g.getNode row col with
            | Empty -> "Empty"
            | Red -> "Red"
            | Yellow -> "Yellow"
        nodeString

    let getNodeColour (g:Game) row col =
        let nodeColour =
            match g.getNode row col with
            | Empty -> ConsoleColor.White
            | Red -> ConsoleColor.Red
            | Yellow -> ConsoleColor.Yellow
        nodeColour

    let updateGame (g:Game) (piece:Node) row col =
        g.setNode piece row col
        g

    let getGame (g:Game) = g

    let decrementInt (i:int) = 
        let j = i - 1
        j

    let plusOne (i:int) = i + 1

    let rec getNextEmptyRow (g:Game) stop row col =
        if stop then 
            row
        elif row = -1 then
            row + 1 //hit the bottom
        else
            if g.getNode row col <> Empty then
                getNextEmptyRow g true (row + 1) col
            else
                getNextEmptyRow g false (row - 1) col

    let dropPiece (g:Game) (piece:Node) col =
        let row = (getNextEmptyRow g false 5 col)
        updateGame g piece row col

    let cprintf c fmt = 
        Printf.kprintf
            (fun s ->
                let old = System.Console.ForegroundColor
                try
                  System.Console.ForegroundColor <- c;
                  System.Console.Write s
                finally
                  System.Console.ForegroundColor <- old)
            fmt

    let cprintfn c fmt =
        cprintf c fmt
        printfn ""

    let stringWithSpace str = 
        sprintf "%s " str

    let printGame (g:Game) =
        for row = 5 downto 0 do
            for col = 0 to 6 do
                cprintf (getNodeColour g row col) "%s " (getNodeString g row col)
            printf "\n"


 


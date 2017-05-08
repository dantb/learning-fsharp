namespace ConnectFour

open System

module ConnectFour =

    type Node =
        | Red
        | Yellow
        | Empty
        
    type Game =
        { Grid : Node[,]
          Winner : string
        }

        member this.getNode row col =
            this.Grid.[row, col]

    let game = 
        { Grid = Array2D.init<Node> 6 7 (fun x y -> Empty) 
          Winner = "" }

    let getNode row col =
        game.getNode row col

    let getNodeString row col =
        let nodeString =
            match getNode row col with
            | Empty -> "Empty"
            | Red -> "Red"
            | Yellow -> "Yellow"
        nodeString

    let printGame =
        for row in 0 .. 5 do
            for col in 0 .. 6 do
                printf "row %i col %i has %s node" row col (getNodeString row col)

 


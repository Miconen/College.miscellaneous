module Extra003

open System

let VALID_ROWS = (1, 8)
let VALID_COLUMNS = (1, 8)

let inRange (value) =
    let (lowX, highX) = VALID_ROWS
    let (lowY, highY) = VALID_COLUMNS
    
    if value < lowX || value > highX then
        false
    else if value < lowY || value > highY then
        false
    else true

let rec getInput (query) =
    printf "%s" query
    let input = Console.ReadLine()
    match Int32.TryParse input with
    | (true, v) -> v
    | (false, _) -> getInput query 

let getMoveCoords targetRank targetFile name =
    match name with
    | "one" -> (targetRank, targetFile - 1) 
    | "two" -> (targetRank - 1, targetFile)
    | "three" -> (targetRank, targetFile + 1)
    | "four" -> (targetRank + 1, targetFile)
    | _ -> raise (ArgumentException("Unknown name."))

let doKnightMove targetRank targetFile name =
    let (rank, file) = getMoveCoords targetRank targetFile name

    if not <| inRange rank then 
        raise (IndexOutOfRangeException("Row not in board range."))   
    else if not <| inRange file then 
        raise (IndexOutOfRangeException("Column not in board range."))   
    else
        Console.ForegroundColor <- ConsoleColor.Red
        printfn "Knight %s to (%i, %i)" name rank file
        Console.ResetColor()
        Console.Beep()

let doKnightsMoves inputRank inputFile =
    Console.Title <- "Sending knights"
    doKnightMove inputRank inputFile "one"
    doKnightMove inputRank inputFile "two"
    doKnightMove inputRank inputFile "three"
    doKnightMove inputRank inputFile "four"

[<EntryPoint>]
let main argv =
    let inputRank = getInput "Target rank?  "
    let inputFile = getInput "Target file? "

    printfn "Sending knights..."
    let testing = doKnightsMoves inputRank inputFile
    0;;

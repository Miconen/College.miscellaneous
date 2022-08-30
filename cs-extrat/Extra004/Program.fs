module Extra004

open System

type Direction =
    | NW = 0
    | N = 1
    | NE = 2
    | W = 3
    | E = 4
    | SW = 5
    | S = 6
    | SE = 7
    
let VALID_ROWS = (-100, 100)
let VALID_COLUMNS = (-100, 100)

let inRange (value) =
    let (lowX, highX) = VALID_ROWS
    let (lowY, highY) = VALID_COLUMNS
    
    if value < lowX || value > highX then
        false
    else if value < lowY || value > highY then
        false
    else
        true

let rec getInput (query) =
    printf "%s" query
    let input = Console.ReadLine()
    match Int32.TryParse input with
    | (true, v) -> v
    | (false, _) -> getInput query 

let coordinatesToDirections (coordinates) =
    let (x, y) = coordinates
    let mutable index = 0;

    // "Direction" enum index math magic
    if y > 0 then
        index <- index + 5
    if y = 0 then
        index <- index + 3
    if x > 0 then
        index <- index + 2
    if x = 0 then
        index <- index + 1

    index

let getDirection coordinates =

    let coordinateIndex = coordinatesToDirections coordinates

    match enum<Direction>(coordinateIndex) with 
    | Direction.NW -> "north west"
    | Direction.N -> "north"
    | Direction.NE -> "north east"
    | Direction.W -> "west"
    | Direction.E -> "east"
    | Direction.SW -> "south west"
    | Direction.S -> "south"
    | Direction.SE -> "south east"

[<EntryPoint>]
let main argv =
    let enemyX = getInput "Enemy X?  "
    let enemyY = getInput "Enemy Y? "
    let coordinates = (enemyX, enemyY)

    let direction = getDirection coordinates 

    printfn "The enemy is to the %s!" direction
    0;;

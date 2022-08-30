module Extra001

open System

[<Literal>]
let BEARS = 4

// "Supports" negative numbers, considered using UInt32 but had problems.
// Also would have to prevent negative input which i couldn't figure out with pattern matching.
// How to add a breakout clause to pattern match when no access to input
let rec getInput () =
    printf "Fish caught (number): "
    let input = Console.ReadLine()
    match Int32.TryParse input with
    | (true, v) -> v
    | (false, _) -> getInput () 

let getCatsFish totalFish =
    totalFish % BEARS

let getBearsFish totalFish =
    (totalFish - getCatsFish totalFish) / BEARS

let printOutput bearsFish catsFish =
    printfn "Bears' fish: %u" bearsFish
    printfn "Cats fish: %u" catsFish

[<EntryPoint>]
let main argv =
    // Get input
    let totalFish = getInput ()
    // Maximum non decimal of totalFish / BEARS
    let bearsFish = getBearsFish totalFish
    // Remainder of totalFish % BEARS
    let catsFish = getCatsFish totalFish
    // Output
    printOutput bearsFish catsFish
    0;;

module Extra005

open System
    
let VALID_GUESS = (0, 100)

let inRange (value) =
    let (low, high) = VALID_GUESS
     
    if value < low || value > high then
        false
    else
        true

let rec getInput (message) =
    printf "%s" message
    let input = Console.ReadLine()
    match Int32.TryParse input with
    | (true , v) -> 
        if inRange v then v
        else
            Console.ForegroundColor <- ConsoleColor.Red
            printfn "Invalid number %i, only numbers between 0 and 100 allowed" v
            Console.ResetColor()
            getInput message
    | (false, _) -> getInput message

let rec gameLoop(target) =
    let guess = getInput "User 2, guess a number between 0 and 100: "
    if guess = target then
        Console.ForegroundColor <- ConsoleColor.Green
        printfn "You guessed %i, which was right!" guess
        Console.ResetColor()
    else if guess > target then
        Console.ForegroundColor <- ConsoleColor.Yellow
        printfn "You guessed %i, which was too high." guess
        Console.ResetColor()
        gameLoop target
    else if guess < target then
        Console.ForegroundColor <- ConsoleColor.Yellow
        printfn "You guessed %i, which was too low." guess
        Console.ResetColor()
        gameLoop target
    else
        gameLoop target
    
[<EntryPoint>]
let main argv =
    // True for player 1 turn, false for player 2 turn
    Console.Clear()
    let target = getInput "User 1, enter a number between 0 and 100: "
    Console.Clear()

    gameLoop target

    Console.Clear()
    0;;

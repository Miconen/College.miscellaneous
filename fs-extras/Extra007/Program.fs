module Extra007

open System

let rec getInput (message) =
    printf "%s" message
    let input = Console.ReadLine()
    match input with
    | "rock" | "paper" | "scissors" -> input
    | _ -> getInput message

let oneWinsOverTwo choices =
    let (one, two) = choices
    if (one = "rock" && two = "rock") then "tied"
    else if (one = "rock" && two = "paper") then "lost"
    else if (one = "rock" && two = "scissors") then "won"
    else if (one = "paper" && two = "rock") then "won"
    else if (one = "paper" && two = "paper") then "tied"
    else if (one = "paper" && two = "scissors") then "lost"
    else if (one = "scissors" && two = "rock") then "lost"
    else if (one = "scissors" && two = "paper") then "won"
    else if (one = "scissors" && two = "scissors") then "tied"
    else "?"


let getRandArrElement =
    let rnd = Random()
    fun (arr : string[]) -> arr.[rnd.Next(arr.Length)]
    
[<EntryPoint>]
let main argv =
    // True for player 1 turn, false for player 2 turn
    Console.Clear()
    let player1 = getInput "User 1, rock, paper or scissors: "
    Console.Clear()
    let player2 = getRandArrElement [| "rock"; "paper"; "scissors" |]
    Console.Clear()

    
    let choices = (player1, player2)
    let status = oneWinsOverTwo choices
    printfn "You %s the game." status
    0;;

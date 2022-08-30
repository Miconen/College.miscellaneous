module Extra002

open System

let POINTS_MAATILA = 1
let POINTS_HERTTUAKUNTA = 3
let POINTS_MAAKUNTA = 6

let rec getInput (query) =
    printf "%s " query
    let input = Console.ReadLine()
    match Int32.TryParse input with
    | (true, v) -> v
    | (false, _) -> getInput query

[<EntryPoint>]
let main argv =
    let maatilat = POINTS_MAATILA * getInput "Maatilat: "
    let herttuakunnat = POINTS_HERTTUAKUNTA * getInput "Herttuakunnat: "
    let maakunnat = POINTS_MAAKUNTA * getInput "Maakunnat: "

    let pointsSum = maatilat + herttuakunnat + maakunnat

    printfn "Pistemäärä: %i" pointsSum
    0;;

module Score

open System
open Domain

let getCardValue card =
    match card.Rank with
    | Ten | Jack | Queen | King -> 10
    | Ace -> 1
    | Two -> 2
    | Three -> 3
    | Four -> 4
    | Five -> 5
    | Six -> 6
    | Seven -> 7
    | Eight -> 8
    | Nine -> 9

let calculateScore hand =
    let baseScore = hand |> List.sumBy getCardValue
    let aceCount = hand |> List.filter (fun c -> c.Rank = Ace) |> List.length

    let rec optimizeScore score aces =
        if aces > 0 && score + 10 <= 21 then
            optimizeScore (score + 10) (aces - 1)
        else
            score
    
    optimizeScore baseScore aceCount
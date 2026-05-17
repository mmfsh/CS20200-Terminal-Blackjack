module Deck

open System
open Domain

let formatCard card =
    let suitStr = 
        match card.Suit with
        | Hearts -> "♥"
        | Diamonds -> "♦"
        | Clubs -> "♣"
        | Spades -> "♠"
    let rankStr = 
        match card.Rank with
        | Ace -> "A"
        | King -> "K"
        | Queen -> "Q"
        | Jack -> "J"
        | Ten -> "10"
        | Nine -> "9"
        | Eight -> "8"
        | Seven -> "7"
        | Six -> "6"
        | Five -> "5"
        | Four -> "4"
        | Three -> "3"
        | Two -> "2"
    sprintf "%s%s" rankStr suitStr

let createDeck () =
    [ for s in [Hearts; Diamonds; Clubs; Spades] do
        for r in [Two; Three; Four; Five; Six; Seven; Eight; Nine; Ten; Jack; Queen; King; Ace] do
            yield { Suit = s; Rank = r } ]

let shuffle deck =
    let rnd = Random()
    deck |> List.sortBy (fun _ -> rnd.Next())

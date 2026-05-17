open System
open Domain
open Deck
open Score

let rec playerTurn deck playerHand dealerHand =
    let score = calculateScore playerHand
    let handStr = playerHand |> List.map formatCard |> String.concat ", "
    printfn "\nYour hand: %s (Score: %d)" handStr score

    if score > 21 then
        printfn "Bust! You went over 21. You lose."
        (deck, playerHand, false)
    else
        printf "Hit (H) or Stand (S)? "
        match Console.ReadLine().Trim().ToUpper() with
        | "H" ->
            let drawn = List.head deck
            printfn "You drew: %s" (formatCard drawn)
            playerTurn (List.tail deck) (playerHand @ [drawn]) dealerHand
        | "S" ->
            printfn "You stand."
            (deck, playerHand, true)
        | _ ->
            printfn "Invalid input. Please enter 'H' or 'S'."
            playerTurn deck playerHand dealerHand

let rec dealerTurn deck dealerHand =
    System.Threading.Thread.Sleep(500)

    let score = calculateScore dealerHand
    let handStr = dealerHand |> List.map formatCard |> String.concat ", "
    printfn "\nDealer's hand: %s (Score: %d)" handStr score

    System.Threading.Thread.Sleep(1000)
    
    if score > 21 then
        printfn "Dealer busts! You win!"
        dealerHand
    elif score <= 16 then
        printfn "Dealer hits."
        System.Threading.Thread.Sleep(1000)

        let drawn = List.head deck
        printfn "Dealer drew: %s" (formatCard drawn)
        dealerTurn (List.tail deck) (dealerHand @ [drawn])
    else
        printfn "Dealer stands."
        dealerHand

[<EntryPoint>]
let main _ =
    printfn "--- Welcome to CLI Blackjack ---"
    let deck = createDeck () |> shuffle
    
    let playerHand = [deck.[0]; deck.[2]]
    let dealerHand = [deck.[1]; deck.[3]]
    let restDeck = deck |> List.skip 4 
    
    printfn "\nDealer's visible card: %s" (formatCard dealerHand.[0])
    
    let (deckAfterPlayer, finalPlayerHand, playerSurvived) = playerTurn restDeck playerHand dealerHand
    
    if playerSurvived then
        printfn "\n--- Dealer's Turn ---"
        let finalDealerHand = dealerTurn deckAfterPlayer dealerHand
        let playerScore = calculateScore finalPlayerHand
        let dealerScore = calculateScore finalDealerHand
        
        if dealerScore <= 21 then
            printfn "\n--- Final Results ---"
            printfn "Your score: %d" playerScore
            printfn "Dealer's score: %d" dealerScore
            
            if playerScore > dealerScore then 
                printfn "You win!"
            elif playerScore < dealerScore then 
                printfn "Dealer wins. You lose."
            else 
                printfn "It's a tie!"
    
    0
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Versioning;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public Sprite[] cardFaces1;
    public Sprite[] cardFaces2;
    public Sprite[] cardFaces3;
    public Sprite[] cardFaces4;

    public int cardFace1Count;
    public int cardFace2Count;
    public int cardFace3Count;
    public int cardFace4Count;
    bool ready = false;
    bool deckReady = false;

    List<GameObject> hand = new();

    List<string> selected = new List<string>();
    List<string[]> selectedCards = new List<string[]>();
    string selectedSuit = "None";
    public int selectedTotal = 0;

    playerDeck pDeck;

    playerDiscard Discard;
    playerDeck Deck;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cardFaces1 = Resources.LoadAll<Sprite>("Swords_Ranks");
        cardFaces2 = Resources.LoadAll<Sprite>("Skulls_Ranks");
        cardFaces3 = Resources.LoadAll<Sprite>("Shields_Ranks");
        cardFaces4 = Resources.LoadAll<Sprite>("Magics_Ranks");
        hand.Add(GameObject.Find("Card 1"));
        hand.Add(GameObject.Find("Card 2"));
        hand.Add(GameObject.Find("Card 3"));
        hand.Add(GameObject.Find("Card 4"));
        hand.Add(GameObject.Find("Card 5"));
        hand.Add(GameObject.Find("Card 6"));
        hand.Add(GameObject.Find("Card 7"));
        hand.Add(GameObject.Find("Card 8"));

        ready = true;

        if (deckReady) { DeckLoaded(); }

        Discard = GameObject.Find("Player Discard").GetComponent<playerDiscard>();
        Deck = GameObject.Find("Player Deck").GetComponent<playerDeck>();
    }

    // Update is called once per frame
    void Update()
    {
        



    }

    /// <summary>
    /// Handles the loading of the player's deck and draws cards into the player's hand if the deck is ready.
    /// </summary>
    /// <remarks>If the deck is ready, this method initializes the player's deck and draws cards into the
    /// hand.  Otherwise, it sets a flag indicating that the deck is ready to be processed later.</remarks>
    public void DeckLoaded()
    {
        if (ready)
        {
            pDeck = GameObject.Find("Player Deck").GetComponent<playerDeck>();

            foreach (GameObject card in hand)
            {
                card.GetComponent<PlayerCard>().Draw(pDeck.Draw());
            }

        }
        else { deckReady = true; }
    }

    /// <summary>
    /// Retrieves the sprite representation of a playing card based on its rank and suit.
    /// </summary>
    /// <remarks>The method maps the rank and suit of the card to a specific sprite from predefined
    /// collections.  Ensure that the input array contains valid rank and suit values to avoid exceptions.</remarks>
    /// <param name="card">An array of two strings representing the card. The first element specifies the rank  (e.g., "A" for Ace, "2"
    /// through "10", "J", "Q", "K"), and the second element specifies  the suit ("Clubs", "Hearts", "Spades", or
    /// "Diamonds").</param>
    /// <returns>The <see cref="Sprite"/> corresponding to the specified card. Returns <see langword="null"/>  if the suit is
    /// invalid or the card cannot be resolved.</returns>
    public Sprite GetCardSprite(string[] card)
    {
        int num;
        if (card[0] == "A") { num = 0; }
        else
        {
            num = int.Parse(card[0]) - 1;
        }
        switch (card[1])
        {
            case "Clubs":
                return cardFaces1[num];
            case "Hearts":
                return cardFaces2[num];
            case "Spades":
                return cardFaces3[num];
            case "Diamonds":
                return cardFaces4[num];
            default:
                return null;

        }
    }

    /// <summary>
    /// Adds the specified card and its position to the selected cards collection.
    /// </summary>
    /// <remarks>The method updates the selected suit, adds the card to the collection, and increments the
    /// total value of selected cards  based on the card's value.</remarks>
    /// <param name="position">The position of the card to add, typically representing its location or identifier.</param>
    /// <param name="card">An array representing the card, where the first element is the card's value and the second element is its suit.</param>
    public void AddSelected(string position, string[] card)
    {
        selectedSuit = card[1];
        selectedCards.Add(card);
        selected.Add(position);
        if (card[0] != "A") { selectedTotal += int.Parse(card[0]); }
    }

    /// <summary>
    /// Removes the specified card and its associated position from the selected items.
    /// </summary>
    /// <remarks>If the card's value is not "A", the total of selected cards is decremented by the numeric
    /// value of the first element of the <paramref name="card"/> array.</remarks>
    /// <param name="position">The position identifier of the card to remove.</param>
    /// <param name="card">An array representing the card to remove. The first element of the array is expected to contain the card's
    /// value.</param>
    public void RemoveSelected(string position, string[] card)
    {
        selectedCards.Remove(card);
        selected.Remove(position);
        if (card[0] != "A") { selectedTotal -= int.Parse(card[0]); }
    }

    /// <summary>
    /// Determines whether the specified card can be selected based on the current selection rules.
    /// </summary>
    /// <remarks>The method checks if the card adheres to the current selection rules, which depend on the
    /// state of the `selected` collection and the `selectedSuit`.  If no cards are currently selected, any card is
    /// valid. If a suit is already selected, the card must match the suit and satisfy additional conditions  related to
    /// its value and the total value of the selected cards.</remarks>
    /// <param name="card">An array representing the card, where the first element is the card value (e.g., "A" or a numeric string) and
    /// the second element is the card suit.</param>
    /// <returns><see langword="true"/> if the card can be selected based on the current selection rules; otherwise, <see
    /// langword="false"/>.</returns>
    public bool CheckSelected(string[] card)
    {
        if (selected == null || selected.Count() == 0)
        {
            return true;
        }
        else if (selectedSuit == card[1])
        {
            if (card[0] == "A" || (int.Parse(card[0]) + selectedTotal) <= 10)
            {
                return true;
            }
            else {
                Debug.Log("Total > 10");
                return false; 
            }
        }
        else
        {
            Debug.Log($"{card[1]} != {selectedSuit}");
            return false;
        }
    }

    /// <summary>
    /// Sends the player's turn data to the turn controller and resets the player's hand and selections.
    /// </summary>
    /// <remarks>This method communicates the player's selected total and suit to the turn controller,
    /// discards all cards in the player's hand,  and clears the player's current selections. After calling this method,
    /// the player's selected suit is reset to "None" and the  selected total is reset to 0.</remarks>
     public void SendTurn()

    {   Debug.Log("Turn Sent");
        GameObject.Find("TurnController").GetComponent<TurnController>().SendPlayerTurn(this.selectedTotal, this.selectedSuit);
        
        foreach (GameObject card in hand)
        {
            if (card.GetComponent<PlayerCard>().selected) { card.GetComponent<PlayerCard>().Discard(); }

            card.GetComponent<PlayerCard>().selected = false;
            card.GetComponent<SpriteRenderer>().color = Color.cyan;


        }


        selected.Clear();
        selectedCards.Clear();
        selectedSuit = "None";
        selectedTotal = 0;
     }

    /// <summary>
    /// Draws the specified number of cards from the deck and assigns them to empty slots in the player's hand.
    /// </summary>
    /// <remarks>This method iterates through the player's hand to identify empty slots and fills them with
    /// cards drawn  from the deck. If the number of empty slots is less than the specified value, only the available
    /// slots  will be filled.</remarks>
    /// <param name="value">The number of cards to draw. Must be a positive integer.</param>
    public void Draw(int value)
    {
        List<GameObject> empty = new();

        foreach (GameObject card in hand)
        {
           if (card.GetComponent<PlayerCard>().card[0] == null)
            {
                empty.Add(card);
            }

        }

        int i = 0;
        while (i < value & i < empty.Count)
        {
            empty[i].GetComponent<PlayerCard>().Draw(pDeck.Draw());
        }
    }


    /// <summary>
    /// Draws new cards for the player, discarding any existing cards in their hand.
    /// </summary>
    /// <remarks>This method iterates through all cards in the player's hand. If a card is not null, it is
    /// discarded  before drawing a new card from the player's deck. The method assumes that each card in the hand  has
    /// a <see cref="PlayerCard"/> component and that the player's deck is accessible via <c>pDeck</c>.</remarks>
    public void JesterDraw()
    {
        foreach (GameObject card in hand)
        {
            if  (card.GetComponent<PlayerCard>().card[0] != null)
            { 
                card.GetComponent<PlayerCard>().Discard();
            
            }

            card.GetComponent<PlayerCard>().Draw(pDeck.Draw());

        }
    }


    public void Heal(int value)
    {
        List<string[]> targets = new(Discard.GetAllCards());

        int i = 0;

        while (i < value | i <= Discard.GetCount())
        {
            string[] target = Discard.GetCard(Random.Range(0, Discard.GetCount()));

            Deck.AddCard(target);
            

        }

    }
}

using NUnit.Framework;
using NUnit.Framework.Internal.Builders;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor.Rendering;
using UnityEngine;

public class playerDeck : MonoBehaviour
{
    string[] numbers = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
    string[] suits = new string[] { "Clubs", "Hearts", "Spades", "Diamonds" };
    List<string[]> deckList = new List<string[]>();
    public int deckSize;
    public int lastCount;
    public string[] lastCard;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(deckSize);
        foreach (string suit in suits)
        {
            foreach (string number in numbers)
            {
                string[] temp = new string[] { number, suit };
                deckList.Add(temp);
            }
        }
        shuffle();
        deckSize = deckList.Count;
        GameObject.Find("PlayerController").GetComponent<PlayerController>().DeckLoaded();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Randomizes the order of elements in the deck list.
    /// </summary>
    /// <remarks>This method shuffles the elements in the <c>deckList</c> collection, ensuring that their
    /// order is randomized.  The operation modifies the original <c>deckList</c> and updates its state
    /// accordingly.</remarks>
    private void shuffle()
    {
        List<string[]> tempList = new List<string[]>();
        while (deckList.Count > 0)
        {
            int rint = Random.Range(0, deckList.Count - 1);
            tempList.Add(deckList[rint]);
            deckList.RemoveAt(rint);
            deckSize = deckList.Count;
            lastCount = rint;
        }
        deckList = tempList;
        
    }

    /// <summary>
    /// Draws the top card from the deck and removes it from the deck.
    /// </summary>
    /// <remarks>After the card is drawn, the deck size is updated, and the drawn card is stored as the last
    /// card.</remarks>
    /// <returns>An array of strings representing the drawn card. The array contains the card's details.</returns>
    public string[] Draw()
    {
        deckSize = this.deckList.Count;

        if (deckSize == 0)
        {
            Debug.Log("The deck is out of cards.");
            return null;
        }
        string[] temp = this.deckList[1];
        deckList.RemoveAt(0);
        deckSize = this.deckList.Count;
        lastCard = temp;
        return temp;
    }

    public void AddCard(string[] card)
    {
        deckList.Add(card);
    }

}

using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class castleDeck : MonoBehaviour
{
    List<string[]> deckList = new List<string[]>();
    public int deckCount;
    public string[] DrawnCard;
    public string[] DeckCard;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // Create the castle deck
        string[] Faces = new string[] { "Jack", "Queen", "King" };
        string[] suits = new string[] { "Clubs", "Hearts", "Spades", "Diamonds" };


        foreach (string face in Faces)
        {
            CreateStack(deckList, face, suits);
        }
        Debug.Log($"castle contains {deckList.Count} cards");
        Debug.Log($"Top card of the castle is {this.deckList[0][0].ToString()} of {this.deckList[0][1]}");
        DrawnCard = deckList[0];
        deckList.RemoveAt(0);
        DeckCard = deckList[0];
        deckCount = deckList.Count;


        // Check for Jester
        //if (GameObject.Find("Castle Controller").GetComponent<CastleController>().Jester)
        //{
          //  string[] jester = new string[] { "Jester", "Jester" };
            //DrawnCard = jester;

        //}

    }
        // Update is called once per frame
        void Update()
    {
        
    }

    /// <summary>
    /// Creates a shuffled stack of cards by combining the specified face value with each suit and appending the
    /// resulting cards to the provided deck.
    /// </summary>
    /// <remarks>The method generates a temporary list of cards by combining the specified face value with
    /// each suit. The cards are then shuffled and added to the provided deck list. The original deck list is modified
    /// directly, and the same list is returned for convenience.</remarks>
    /// <param name="DeckList">The list to which the generated cards will be added. This list is modified in place.</param>
    /// <param name="Face">The face value to assign to each card in the stack (e.g., "Ace", "King").</param>
    /// <param name="Suits">An array of suits to combine with the face value (e.g., "Hearts", "Diamonds").</param>
    /// <returns>The updated deck list containing the newly added shuffled cards.</returns>
    private List<string[]> CreateStack(List<string[]> DeckList, string Face, string[] Suits)


    {
        List<string[]> tempDeckList = new List<string[]>();

        foreach (string suit in Suits)
        {
            string[] card = new string[] { Face, suit };
            tempDeckList.Add(card);
        }

        while (tempDeckList.Count > 0)
        {
            int i = Random.Range(0, tempDeckList.Count);
            DeckList.Add(tempDeckList[i]);
            Debug.Log($"Stacked {tempDeckList[i][0].ToString()} of {tempDeckList[i][1].ToString()} ");
            tempDeckList.RemoveAt(i);

        }
        return DeckList;
    }

    public string[] GetDrawnCard()

    {
        

        return this.DrawnCard;
    }

    public string[] GetTopCard()
    {
        return this.DeckCard;
    }
}

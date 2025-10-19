using NUnit.Framework;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
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

    List<string> selected = new List<string>();
    List<string[]> selectedCards = new List<string[]>();
    string selectedSuit = "None";
    public int selectedTotal = 0;

    playerDeck pDeck;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cardFaces1 = Resources.LoadAll<Sprite>("Swords_Ranks");
        cardFaces2 = Resources.LoadAll<Sprite>("Skulls_Ranks");
        cardFaces3 = Resources.LoadAll<Sprite>("Shields_Ranks");
        cardFaces4 = Resources.LoadAll<Sprite>("Magics_Ranks");
        ready = true;
        if (deckReady) { DeckLoaded(); }


    }

    // Update is called once per frame
    void Update()
    {
        



    }

    public void DeckLoaded()
    {
        if (ready)
        {
            pDeck = GameObject.Find("Player Deck").GetComponent<playerDeck>();


            GameObject.Find("Card 1").GetComponent<PlayerCard>().Draw(pDeck.Draw());
            GameObject.Find("Card 2").GetComponent<PlayerCard>().Draw(pDeck.Draw());
            GameObject.Find("Card 3").GetComponent<PlayerCard>().Draw(pDeck.Draw());
            GameObject.Find("Card 4").GetComponent<PlayerCard>().Draw(pDeck.Draw());
            GameObject.Find("Card 5").GetComponent<PlayerCard>().Draw(pDeck.Draw());
            GameObject.Find("Card 6").GetComponent<PlayerCard>().Draw(pDeck.Draw());
            GameObject.Find("Card 7").GetComponent<PlayerCard>().Draw(pDeck.Draw());
            GameObject.Find("Card 8").GetComponent<PlayerCard>().Draw(pDeck.Draw());
        }
        else { deckReady = true; }
    }

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

    public void AddSelected(string position, string[] card)
    {
        selectedSuit = card[1];
        selectedCards.Add(card);
        selected.Add(position);
        if (card[0] != "A") { selectedTotal += int.Parse(card[0]); }
    }

    public void RemoveSelected(string position, string[] card)
    {
        selectedCards.Remove(card);
        selected.Remove(position);
        if (card[0] != "A") { selectedTotal -= int.Parse(card[0]); }
    }

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

}

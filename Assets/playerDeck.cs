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
        GameObject.Find("Game Master").GetComponent<GameMaster>().DeckLoaded();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    public string[] Draw()
    {
        deckSize = this.deckList.Count;
        string[] temp = this.deckList[1];
        deckList.RemoveAt(0);
        deckSize = this.deckList.Count;
        lastCard = temp;
        return temp;
    }

}

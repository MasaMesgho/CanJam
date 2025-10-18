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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (string suit in suits)
        {
            foreach (string number in numbers)
            {
                string[] temp = new string[] { number, suit };
                deckList.Add(temp);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string[] Draw()
    {
        int rint = Random.Range(0, deckList.Count - 1);
        string[] temp = deckList[rint];
        deckList.Remove(temp);
        return temp;
    }

}

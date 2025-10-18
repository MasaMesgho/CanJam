using NUnit.Framework;
using NUnit.Framework.Internal.Builders;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class deck : MonoBehaviour
{
    List<int> numbers = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    List<string> suits = new List<string> { "Club", "Heart", "Spade", "Diamond" };
    List<string> deckList = new List<string>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (string suit in suits)
        {
            foreach (int number in numbers)
            {
                deckList.Add("{suit} {number}");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

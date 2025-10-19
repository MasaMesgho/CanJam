using System.Collections.Generic;
using UnityEngine;

public class castleDeck : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string[] Faces = new string[] { "Jack", "Queen", "King" };
        string[] suits = new string[] { "Clubs", "Hearts", "Spades", "Diamonds" };
        List<string[]> deckList = new List<string[]>();


        foreach (string face in Faces)
        {
            CreateStack(deckList, face, suits);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private List<string[]> CreateStack(List<string[]> deckList, string Face, string[] Suits)


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
            deckList.Add(tempDeckList[i]);
            Debug.Log($"Stacked {tempDeckList[i][0].ToString()} of {tempDeckList[i][1].ToString()} ");
            tempDeckList.RemoveAt(i);

        }
        return deckList;
    }


}

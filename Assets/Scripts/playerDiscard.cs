using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class playerDiscard : MonoBehaviour
{

    List<string[]> discardList = new List<string[]>();
    string[] lastAdded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCard(string[] card)
    {
        discardList.Add(card);
        lastAdded = card;
    }

    public List<string[]> GetAllCards()
    {
        List<string[]> temp = discardList;
        discardList.Clear();
        string[] temp2 = new string[2];
        temp2.AddRange("None");
        lastAdded = temp2;
        return temp;
    }

    public int GetCount()
    { return discardList.Count; }

    public string[] GetCard(int pos)
    {

        string[] card = discardList[pos];
        discardList.Remove(card);
        return card;
    }
}

using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerCard : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var deck = GameObject.Find("Player Deck");
        string[] card = deck.GetComponent<playerDeck>().Draw();
        deck = default;
        Sprite cardFace = Resources.Load<Sprite>("Cards\\Fantasy_Cards_0");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = cardFace;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

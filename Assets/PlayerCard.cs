using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerCard : MonoBehaviour
{
    public string[] card;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var deck = GameObject.Find("Player Deck");
        this.card = deck.GetComponent<playerDeck>().Draw();
        deck = default;
        Sprite[] cardFaces1 = Resources.LoadAll<Sprite>("Swords_Ranks");
        Sprite[] cardFaces2 = Resources.LoadAll<Sprite>("Skulls_Ranks");
        Sprite[] cardFaces3 = Resources.LoadAll<Sprite>("Shields_Ranks");
        Sprite[] cardFaces4 = Resources.LoadAll<Sprite>("Magics_Ranks");
        int num;
        if (card[0] == "A") { num = 0; }
        else
        {
            num = int.Parse(card[0])-1;
        }
        switch (card[1])
        {
            case "Clubs":
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cardFaces1[num];
                break;
            case "Hearts":
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cardFaces2[num];
                break;
            case "Diamonds":
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cardFaces4[num];
                break;
            case "Spades":
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cardFaces3[num];
                break;

        }
    }

        // Update is called once per frame
    void Update()
    {
        
    }

    public void Discard()
    {
        var discard = GameObject.Find("Player Discard");
        discard.GetComponent<playerDiscard>().AddCard(this.card);
        this.enabled = false;
    }
    public void Draw()
    {
        var deck = GameObject.Find("Player Deck");
        this.card = deck.GetComponent<playerDeck>().Draw();
    }

}

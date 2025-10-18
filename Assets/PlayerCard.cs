using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerCard : MonoBehaviour
{
    string[] card;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var deck = GameObject.Find("Player Deck");
        this.card = deck.GetComponent<playerDeck>().Draw();
        deck = default;
        Sprite[] cardFaces = Resources.LoadAll<Sprite>("FantasyCards");
        int num;
        if (card[0] == "A") { num = 0; }
        else
        {
            num = int.Parse(card[0]);
        }
        switch (card[1])
        {
            case "Clubs":
                break;
            case "Hearts":
                num += 13;
                break;
            case "Diamond":
                num += 26;
                break;
            case "Spades":
                num += 39;
                break;

        }
        this.gameObject.GetComponent<SpriteRenderer>().sprite = cardFaces[num];
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

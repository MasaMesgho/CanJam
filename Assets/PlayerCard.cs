using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class PlayerCard : MonoBehaviour
{
    public string[] card;
    public bool selected = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.GetComponent<SpriteRenderer>().color = Color.cyan;
    }

        // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selected)
            {
                this.GetComponent<SpriteRenderer>().color = Color.cyan;
                this.selected = false;
                GameObject.Find("Game Master").GetComponent<GameMaster>().RemoveSelected(this.name, this.card);
            }
            else
            {
                if (GameObject.Find("Game Master").GetComponent<GameMaster>().CheckSelected(card[1]))
                {
                    this.GetComponent<SpriteRenderer>().color = Color.white;
                    this.selected = true;
                    GameObject.Find("Game Master").GetComponent<GameMaster>().AddSelected(this.name, this.card);
                }
            }
        }
    }

    public void OnClick()
    {
        Debug.Log(card);
        if (selected)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(53, 173, 129);
            this.selected = false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
            this.selected = true;
        }
    }


    public void Discard()
    {
        var discard = GameObject.Find("Player Discard");
        discard.GetComponent<playerDiscard>().AddCard(this.card);
        this.enabled = false;
    }
    public void Draw(string[] Card)
    {
        this.card = Card;
        this.GetComponent<SpriteRenderer>().sprite = GameObject.Find("Game Master").GetComponent<GameMaster>().GetCardSprite(Card);
    }

}

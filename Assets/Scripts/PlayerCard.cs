using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;
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
        if (Input.GetMouseButtonDown(0) && this.GetComponent<PlayerCard>().card[0] != null)   
        {
            if (selected)
            {
                this.GetComponent<SpriteRenderer>().color = Color.cyan;
                this.selected = false;
                GameObject.Find("PlayerController").GetComponent<PlayerController>().RemoveSelected(this.name, this.card);
            }
            else
            {
                if (GameObject.Find("PlayerController").GetComponent<PlayerController>().CheckSelected(card) )
                {
                    this.GetComponent<SpriteRenderer>().color = Color.white;
                    this.selected = true;
                    GameObject.Find("PlayerController").GetComponent<PlayerController>().AddSelected(this.name, this.card);
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

    /// <summary>
    /// Discards the current card by adding it to the player's discard pile.
    /// </summary>
    /// <remarks>This method locates the player's discard pile and adds the associated card to it.  Once the
    /// card is discarded, the current object is disabled.</remarks>
    public void Discard()
    {
        var discard = GameObject.Find("Player Discard");
        discard.GetComponent<playerDiscard>().AddCard(this.card);
        this.card[0] = null;
        this.card[1] = null;
        this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Card");
        
        this.enabled = false;
    }

    /// <summary>
    /// Updates the card display by setting the sprite based on the specified card data.
    /// </summary>
    /// <remarks>The method retrieves the appropriate sprite for the card by interacting with the
    /// PlayerController component. Ensure that the card data provided is valid and that the PlayerController component
    /// is properly configured.</remarks>
    /// <param name="Card">An array of strings representing the card data. The data is used to determine the sprite to display.</param>
    public void Draw(string[] Card)
    {
        this.card = Card;
        this.GetComponent<SpriteRenderer>().sprite = GameObject.Find("PlayerController").GetComponent<PlayerController>().GetCardSprite(Card);
    }

}

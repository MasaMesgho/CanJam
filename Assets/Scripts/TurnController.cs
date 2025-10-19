using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    //public fields
    public GameObject turnButton;
    public GameObject castleController;
    public GameObject playerController;
    public GameObject TurnPointer;


    //private fields
    private CastleController Castle;


    private PlayerController Player;

    public bool Jester = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         Castle = castleController.GetComponent<CastleController>();
         Player = playerController.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendPlayerTurn(int total, string suit)

    {

        int CastleIncomingAttack = this.Castle.GetDamage();

        //catch if the player decked out first


        //Castle Damage Logic
        int hp = Castle.TakeDamage(total);

        switch (hp)
        {
            case int n when (n < 0):
                Debug.Log("Castle should draw a new foe!");
                break;
            case int n when (n == 0):
                Debug.Log("Castle should add to player deck!");
                break;
            default:
                Debug.Log("Castle should attack!");
                break;
        }

        //Player Power Logic

        string[] CastleSuit;


             CastleSuit = Castle.Deck.GetDrawnCard();


        {
            if (suit != CastleSuit[1])
            {


                switch (suit)

                {
                    case "Clubs":
                        { hp = Castle.TakeDamage(total); break; }

                    case "Hearts":
                        { Player.Heal(total); break; }

                    case "Spades":
                        { Castle.ReduceDamage(total); break; }

                    case "Diamonds":
                        { Player.Draw(total); break; }
                }

            }

        }

        //enemy attack sequence

        //go again


    }
}

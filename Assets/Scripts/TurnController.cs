using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{

    public GameObject turnButton;
    public GameObject CastleController;
    public GameObject PlayerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendPlayerTurn(int total, string suit)

    {

        //catch if the player decked out first

        
        //Castle Damage Logic
        int hp = CastleController.GetComponent<CastleController>().TakeDamage(total);

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

        //enemy attack sequence

        //go again


    }
}

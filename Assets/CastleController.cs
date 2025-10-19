using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CastleController : MonoBehaviour
{

    /*public GameObject CurrentCastle; */
    public castleDeck CastleDeck;
    public GameObject PowerDial;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       


       
    }

    // Update is called once per frame
    void Update()
    {
        string currentSuit = CastleDeck.GetTopCard()[1];

        switch (currentSuit)

        {
            case "Clubs":
                {
                    PowerDial.transform.GetChild(0).gameObject.SetActive(false);
                    PowerDial.transform.GetChild(1).gameObject.SetActive(true);
                    PowerDial.transform.GetChild(2).gameObject.SetActive(true);
                    PowerDial.transform.GetChild(3).gameObject.SetActive(true);
                    break;
                }
            case "Hearts":
                {
                    PowerDial.transform.GetChild(0).gameObject.SetActive(true);
                    PowerDial.transform.GetChild(1).gameObject.SetActive(false);
                    PowerDial.transform.GetChild(2).gameObject.SetActive(true);
                    PowerDial.transform.GetChild(3).gameObject.SetActive(true);
                    break;
                }
            case "Spades":
                {
                    PowerDial.transform.GetChild(0).gameObject.SetActive(true);
                    PowerDial.transform.GetChild(1).gameObject.SetActive(true);
                    PowerDial.transform.GetChild(2).gameObject.SetActive(false);
                    PowerDial.transform.GetChild(3).gameObject.SetActive(true);
                    break;
                }
            case "Diamonds":
                {
                    PowerDial.transform.GetChild(0).gameObject.SetActive(true);
                    PowerDial.transform.GetChild(1).gameObject.SetActive(true);
                    PowerDial.transform.GetChild(2).gameObject.SetActive(true);
                    PowerDial.transform.GetChild(3).gameObject.SetActive(false);
                    break;
                }
        }
    }
}

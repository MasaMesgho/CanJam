using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CastleController : MonoBehaviour
{

    /*public GameObject CurrentCastle; */
    public castleDeck CastleDeck;
    public GameObject PowerDial;
    public bool Jester = true;

    public int hp;
    public int damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = 30;
        damage = 1;

       
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
            default:
                {
                    PowerDial.transform.GetChild(0).gameObject.SetActive(true);
                    PowerDial.transform.GetChild(1).gameObject.SetActive(true);
                    PowerDial.transform.GetChild(2).gameObject.SetActive(true);
                    PowerDial.transform.GetChild(3).gameObject.SetActive(true);
                    break;
                }
        }
    }

    /// <summary>
    /// Reduces the castle's health points (HP) by the specified damage amount.
    /// </summary>
    /// <remarks>If the damage reduces the castle's HP below zero, the resulting HP will reflect the negative
    /// value.</remarks>
    /// <param name="dam">The amount of damage to apply. Must be a non-negative integer.</param>
    /// <returns>The remaining health points (HP) of the castle after applying the damage.</returns>
    public int TakeDamage(int dam)
    { 
     
        hp -= dam;
        Debug.Log($"Castle took {dam} damage, {hp} HP remaining.");

        return hp;
    }

}

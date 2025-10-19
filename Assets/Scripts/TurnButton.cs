using UnityEngine;

public class TurnButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Player Turn Ended");

            GameObject.Find("PlayerController").GetComponent<PlayerController>().SendTurn();
        }
    }


}

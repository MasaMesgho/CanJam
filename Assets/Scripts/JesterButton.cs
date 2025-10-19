using UnityEngine;

public class JesterButton : MonoBehaviour
{
    public GameObject jester;
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
            Debug.Log("Player used a Jester");

            //GameObject.Find("PlayerController").GetComponent<PlayerController>().JesterDraw();
            GameObject.Find("PlayerController").GetComponent<PlayerController>().Draw(5);
            //jester.SetActive(false);
        }
    }
}

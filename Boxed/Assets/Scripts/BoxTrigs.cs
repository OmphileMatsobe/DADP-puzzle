using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigs : MonoBehaviour
{
    [SerializeField] string side;
    [SerializeField] GameObject parent;
    public bool vertTrig, horTrig;
    bool playerContact;

    // Start is called before the first frame update
    void Start()
    {
        vertTrig = horTrig = false;
        playerContact = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            if ((side == "Top" || side == "Bottom"))
            {
                vertTrig = true;
            }
            else if ((side == "Left" || side == "Right"))
            {
                horTrig = true;
            }
        }

        if (collision.gameObject.tag == "Player")
        {
            playerContact = true;
            parent.GetComponent<BoxMovement>().state = true;
            Debug.Log("Enter");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (vertTrig == true)
        {
            vertTrig = false;
        }
        else if (horTrig == true)
        {
            horTrig = false;
        }
        
        
        Debug.Log("Exit");
        parent.GetComponent<BoxMovement>().state = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] GameObject dest;
    [SerializeField] Vector2 inputVec;
    [SerializeField] string direction; 
    
    Vector2 addVec, correctionVec;
    GameObject player;
    Vector2 move;
    bool allowMove = false;

    // Start is called before the first frame update
    void Start()
    {
        if (direction == "HR")
            addVec = new Vector2(1,0);
        else if (direction == "HL")
            addVec = new Vector2(-1,0);
        if (direction == "VU")
            addVec = new Vector2(0,1);
        else if (direction == "VD")
            addVec = new Vector2(0,-1);

        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            allowMove = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        allowMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        move.y = Input.GetAxisRaw("Vertical");
        move.x = Input.GetAxisRaw("Horizontal");

        if (move.y > 0)
        {
            move.y = 1f;
        }
        else if (move.y < 0) 
        {
            move.y = -1f;
        }

        if (move.x > 0)
        {
            move.x = 1f;
        }
        else if (move.x < 0)
        {
            move.x = -1f;
        }


        correctionVec = dest.transform.position;

        if (allowMove)
        {
            if (move == inputVec)
            {
                player.transform.position = correctionVec + addVec;
            }
        }
    }
}

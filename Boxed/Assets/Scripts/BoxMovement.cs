using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    [SerializeField] GameObject top, bottom, left, right;
    [SerializeField] int id;
    public bool state;
    GameObject mainBox;
    bool vertMove, horMove;
    bool moveMain = false;
    GameObject player;
    Vector2 setVec, setMainVec, movement;
    bool contact = false;

    // Start is called before the first frame update
    void Start()
    {
        state = false;
        player = GameObject.FindWithTag("Player");
        mainBox = GameObject.FindWithTag("MainBox");
    }

    private void Move()
    {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");

            movement.Normalize();
           

            setVec = transform.position;
            setMainVec = mainBox.transform.localPosition;

            if (top.GetComponent<BoxTrigs>().vertTrig == false && bottom.GetComponent<BoxTrigs>().vertTrig == false)
            {
                if (mainBox.GetComponent<MainBoxMove>().mainVertMove == true)
                {
                    vertMove = true;
                }
            }
            else
            {
                vertMove = false;
            }

            if (top.GetComponent<BoxTrigs>().horTrig == false && bottom.GetComponent<BoxTrigs>().horTrig == false)
            {
                if (mainBox.GetComponent<MainBoxMove>().mainHorMove == true)
                {
                    horMove = true;
                }
            }
            else
            {
                horMove = false;
            }

            Debug.Log(state + " , id: " + id);
            transform.position = setVec;
            mainBox.transform.localPosition = setMainVec;
        }
    }


    // Update is called once per frame
    void Update()
    {
        Move();
        
    }
}

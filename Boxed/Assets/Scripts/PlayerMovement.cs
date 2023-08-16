using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 Movement = new Vector2();
    Vector2 changePos;
    bool lockState;
    public bool move;

    // Start is called before the first frame update
    void Start()
    {
        lockState = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {        
    }

    private void FixedUpdate()
    {
        if (!lockState) 
        {
            moveCharacter();
        }
    }

    IEnumerator Check()
    {
        yield return new WaitForSeconds(0.2f);        
        lockState = false;
    }

    void moveCharacter()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxis("Vertical");
        Movement.Normalize();

        changePos = transform.position;

        if (Movement.y != 0 && Movement.x == 0)
        {
            changePos.y += Movement.y;
            transform.position = changePos;
            move = true;
            lockState = true;
            StartCoroutine(Check());
        }

        else if (Movement.x != 0 && Movement.y == 0)
        {
            changePos.x += Movement.x;
            transform.position = changePos;
            move = true;
            lockState = true;
            StartCoroutine(Check());
        }
        else
        {
            move = false;
        }
    }
}

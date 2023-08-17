using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject top, bottom, left, right;
    Rigidbody2D rb;
    public Vector2 Movement = new Vector2();
    Vector2 changePos;
    bool lockState;
    public bool move;
    int topCollisionWall, bottomCollisionWall, leftCollisionWall, rightCollisionWall; 

    // Start is called before the first frame update
    void Start()
    {
        topCollisionWall = 1;
        bottomCollisionWall = 0;
        leftCollisionWall = 0;
        rightCollisionWall = 0;

        lockState = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        topCollisionWall = top.GetComponent<OnTriggerPlayer>().trigState;
        bottomCollisionWall = bottom.GetComponent<OnTriggerPlayer>().trigState;
        leftCollisionWall = left.GetComponent<OnTriggerPlayer>().trigState;
        rightCollisionWall = right.GetComponent<OnTriggerPlayer>().trigState;
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
        yield return new WaitForSeconds(0.25f);        
        lockState = false;
    }

    void moveCharacter()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxis("Vertical");
        Movement.Normalize();

        

        if (topCollisionWall == 1)
        {
            if (Movement.y > 0)
                Movement.y = 0;
        }
        else if (bottomCollisionWall == 1)
        {
            if (Movement.y < 0)
                Movement.y = 0;
        }
        
        if (leftCollisionWall == 1)
        {
            if (Movement.x < 0)
                Movement.x = 0;
        }
        else if (rightCollisionWall == 1)
        {
            if (Movement.x > 0)
                Movement.x = 0;
        }

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

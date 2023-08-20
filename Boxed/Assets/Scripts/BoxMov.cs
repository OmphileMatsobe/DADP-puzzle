
using System.Collections;
using UnityEngine;

public class BoxMov : MonoBehaviour
{
    [SerializeField] GameObject top, bottom, left, right;
    GameObject mainTop, mainBottom, mainLeft, mainRight;
    int topInt, bottomInt, leftInt, rightInt, lockInt;
    int topWallInt, bottomWallInt, leftWallInt, rightWallInt;
    int topMainWallInt, bottomMainWallInt, leftMainWallInt, rightMainWallInt;
    GameObject player, main;
    Vector2 Movement;
    Vector2 trackPos, trackMainPos;

    // Start is called before the first frame update
    void Start()
    {
        lockInt = 0;
        player = GameObject.FindWithTag("Player");
        main = GameObject.FindWithTag("MainBox");
        mainTop = GameObject.FindWithTag("MainTop");
        mainBottom = GameObject.FindWithTag("MainBottom");
        mainLeft = GameObject.FindWithTag("MainLeft");
        mainRight = GameObject.FindWithTag("MainRight");
    }


    IEnumerator delayFun()
    {
        yield return new WaitForSeconds(0.25f);
        lockInt = 0;
    }
    // Update is called once per frame
    void Update()
    {
        trackPos = transform.position;
        trackMainPos = main.transform.position;
        Move();
    }

    private void Move()
    {
        
        Movement.x = Input.GetAxis("Horizontal");
        Movement.y = Input.GetAxis("Vertical");
        Movement.Normalize();

        topInt = top.GetComponent<OnTriggerBoxes>().playerContState;
        bottomInt = bottom.GetComponent<OnTriggerBoxes>().playerContState;
        leftInt = left.GetComponent<OnTriggerBoxes>().playerContState;
        rightInt = right.GetComponent<OnTriggerBoxes>().playerContState;

        topWallInt = top.GetComponent<OnTriggerBoxes>().wallTrigState;
        bottomWallInt = bottom.GetComponent<OnTriggerBoxes>().wallTrigState;
        leftWallInt = left.GetComponent<OnTriggerBoxes>().wallTrigState;
        rightWallInt = right.GetComponent<OnTriggerBoxes>().wallTrigState;

        topMainWallInt = mainTop.GetComponent<OnTriggerBoxes>().wallTrigState;
        bottomMainWallInt = mainBottom.GetComponent<OnTriggerBoxes>().wallTrigState;
        leftMainWallInt = mainLeft.GetComponent<OnTriggerBoxes>().wallTrigState;
        rightMainWallInt = mainRight.GetComponent<OnTriggerBoxes>().wallTrigState;



        if (leftInt == 1 && rightWallInt == 0 && rightMainWallInt == 0)
        {
            if (Movement.x == 1f && lockInt == 0)
            {
                trackPos.x += 1f;
                trackMainPos.x += 1f;
                lockInt = 1;    
                StartCoroutine(delayFun());
            }
        }
        else if (rightInt == 1 && leftWallInt == 0 && leftMainWallInt == 0)
        {
            if (Movement.x == -1f && lockInt == 0)
            {
                trackPos.x -= 1f;
                trackMainPos.x -= 1f;
                lockInt = 1;
                StartCoroutine(delayFun());              
            }
        }

        if (bottomInt == 1 && topWallInt == 0 && topMainWallInt == 0)
        {
            if (Movement.y == 1 && lockInt == 0)
            {
                trackPos.y += 1f;
                trackMainPos.y += 1f;
                lockInt = 1;
                StartCoroutine(delayFun());
            }
        }

        else if (topInt == 1 && bottomWallInt == 0 && bottomMainWallInt == 0)
        {
            if (Movement.y == -1 && lockInt == 0)
            {
                trackPos.y -= 1f;
                trackMainPos.y -= 1f;
                lockInt = 1;
                StartCoroutine(delayFun());
            }
        }

        transform.position = trackPos;
        main.transform.position = trackMainPos;
    }
}

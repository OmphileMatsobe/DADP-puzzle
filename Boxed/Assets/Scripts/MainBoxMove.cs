using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainBoxMove : MonoBehaviour
{
    [SerializeField] GameObject top, bottom, left, right;
    public bool mainVertMove, mainHorMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (top.GetComponent<MainBoxTrigs>().vertTrig == false && bottom.GetComponent<MainBoxTrigs>().vertTrig == false)
        {
            mainVertMove = true;
        }
        else
        {
            mainVertMove = false;
        }

        if (top.GetComponent<MainBoxTrigs>().horTrig == false && bottom.GetComponent<MainBoxTrigs>().horTrig == false)
        {
            mainHorMove = true;
        }
        else
        {
            mainHorMove = false;
        }
    }
}

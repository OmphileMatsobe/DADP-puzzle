using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBoxTrigs : MonoBehaviour
{
    [SerializeField] string side;
    public bool vertTrig, horTrig;

    // Start is called before the first frame update
    void Start()
    {
        vertTrig = horTrig= false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (side == "Top" || side == "Bottom")
        {
            vertTrig = true;
        }
        else if (side == "Left" || side == "Right")
        {
            horTrig = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((side == "Top" || side == "Bottom") && vertTrig)
        {
            vertTrig = false;
        }
        else if ((side == "Left" || side == "Right") && horTrig)
        {
            horTrig = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}

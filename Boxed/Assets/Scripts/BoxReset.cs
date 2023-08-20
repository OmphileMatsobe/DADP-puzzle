using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxReset : MonoBehaviour
{
    [SerializeField] GameObject box;
    [SerializeField] GameObject spawm;
    GameObject gm;
    bool AllowMove;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameManager");
        AllowMove = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            if (gm.GetComponent<GameManager>().RubyCount > 0)
            {
                Debug.Log("AllowMove");
                AllowMove = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        AllowMove = false;
        Debug.Log("AllowMove False");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (AllowMove == true)
            {
                Debug.Log("KeyPressed");
                box.transform.position = spawm.transform.position;
                gm.GetComponent<GameManager>().RubyCount--;
            }
        }

    }
}

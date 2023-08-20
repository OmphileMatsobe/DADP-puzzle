using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{
    GameObject gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameManager");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainBox")
        {
            Destroy(this.gameObject);
            gm.GetComponent<GameManager>().RubyCount++;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

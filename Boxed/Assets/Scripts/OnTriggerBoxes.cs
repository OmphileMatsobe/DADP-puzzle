using System.Collections;
using UnityEngine;

public class OnTriggerBoxes : MonoBehaviour
{
    public int wallTrigState = 0;
    public int playerContState = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Portal")
        {
            wallTrigState = 1;
        }

        else if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(delay());
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.25f);
        playerContState = 1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Portal") && wallTrigState == 1)
        {
            wallTrigState = 0;
        }
        else if (collision.gameObject.tag == "Player" && playerContState == 1)
        {
            playerContState = 0;
        }
    }
}

using UnityEngine;

public class OnTriggerPlayer : MonoBehaviour
{
    public int trigState = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Box")
        {
            trigState = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Box")  && trigState == 1)
        {
            trigState = 0;
        }
        
    }
}

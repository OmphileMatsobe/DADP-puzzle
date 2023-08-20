using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject RubyStone;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(RubyStone, new Vector2(0.5f, 0.5f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

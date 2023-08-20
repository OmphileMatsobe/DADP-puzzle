using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject RubyStone;
    [SerializeField] Vector2 spawn1, spawn2, spawn3;
    [SerializeField] Image RubyOne, RubyTwo, RubyThree, RubyFour, RubyFive;
    public int RubyCount;

    List<GameObject> Ruby = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        RubyCount = 0;
        Instantiate(RubyStone, spawn1, Quaternion.identity);
        Ruby.Add(RubyStone);
        StartCoroutine(delayOne());
        StartCoroutine(delayTwo());

        RubyOne.GetComponent<Image>().enabled = false;
        RubyTwo.GetComponent<Image>().enabled = false;
        RubyThree.GetComponent<Image>().enabled = false;
    }

    IEnumerator delayOne()
    {
        yield return new WaitForSeconds(120);
        Instantiate(RubyStone, spawn2, Quaternion.identity);
        Ruby.Add(RubyStone);
    }

    IEnumerator delayTwo()
    {
        yield return new WaitForSeconds(120);
        Instantiate(RubyStone, spawn3, Quaternion.identity);
        Ruby.Add(RubyStone);
    }

    // Update is called once per frame
    void Update()
    {

        if (RubyCount > 0)
            RubyOne.GetComponent<Image>().enabled = true;
        else
            RubyOne.GetComponent<Image>().enabled = false;
        if (RubyCount > 1)
            RubyTwo.GetComponent<Image>().enabled = true;
        else
            RubyTwo.GetComponent<Image>().enabled = false;
        if (RubyCount > 2)
            RubyThree.GetComponent<Image>().enabled = true;
        else
            RubyThree.GetComponent<Image>().enabled = false;

        if (RubyCount > 3)
            RubyFour.GetComponent<Image>().enabled = true;
        else
            RubyFour.GetComponent<Image>().enabled = false;
        if (RubyCount > 4)
            RubyTwo.GetComponent<Image>().enabled = true;
        else
            RubyFive.GetComponent<Image>().enabled = false;

    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenemanager : MonoBehaviour
{

    public GameObject how2PlayMenu; 
    public GameObject mainMenu; 

    public void OnHowToPlayButtonClicked()
    {
        how2PlayMenu.SetActive(true); 
    }

    
    public void OnExitButtonClicked()
    {
        mainMenu.SetActive(true); 
    }

}

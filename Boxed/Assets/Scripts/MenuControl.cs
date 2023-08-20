using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void TutoralMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }

    public void LevelOne()
    {
        SceneManager.LoadScene(3);
    }
    public void LevelTwo()
    {
        SceneManager.LoadScene(4);
    }

    public void LevelThree()
    {
        SceneManager.LoadScene(5);
    }

    public void LevelFour()
    {
        SceneManager.LoadScene(6);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

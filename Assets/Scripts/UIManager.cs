using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update

    public void toProlog()
    {
        Debug.Log("toProlog");
        SceneManager.LoadScene("Prolog v2");
    }

    public void toGame()
    {
        Debug.Log("toGame");
        SceneManager.LoadScene("PlayingScene");
    }
    
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

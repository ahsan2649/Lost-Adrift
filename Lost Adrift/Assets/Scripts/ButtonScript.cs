using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{

    public void startGame()
    {
        SceneManager.LoadScene("Cutscene_End", LoadSceneMode.Single);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}

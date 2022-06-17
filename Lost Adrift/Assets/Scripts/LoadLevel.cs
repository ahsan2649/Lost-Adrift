using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

    public void LoadLevelFunction(string levelName)
    {

        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }
}

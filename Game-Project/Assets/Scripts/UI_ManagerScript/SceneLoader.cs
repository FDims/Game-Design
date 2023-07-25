using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void CreditsGame()
    {
        SceneManager.LoadScene(6);
    }

    public void QuitGame()
    {
        Application.Quit();
        //Debug.Log("Quit!");
    }
}

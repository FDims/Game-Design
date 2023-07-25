using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{  
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeLevel(int id)
    {
        if (AudioListener.pause) AudioListener.pause = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(id);
    }

    public void MainMenu()
    {
        if (AudioListener.pause) AudioListener.pause = false;
        Time.timeScale = 1f; 
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        if (AudioListener.pause) AudioListener.pause = false;
        Time.timeScale = 1f;
        int SceneNumber = SceneManager.GetActiveScene().buildIndex;
        if (SceneNumber == 3 || SceneNumber == 5) SceneNumber--;
        SceneManager.LoadScene(SceneNumber);
    }

    public void ExitGame()
    {
        //EditorApplication.isPlaying = false;
    }
}

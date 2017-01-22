using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Lose()
    {
        LoadLevel("Loss");
    }

    public void Win()
    {
        LoadLevel("Win");
    }
}

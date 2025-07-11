using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        StartCoroutine(LaunchRoutine());

    }


    IEnumerator LaunchRoutine()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("StudioScene");

        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MenuScene");

    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("OptionsScene");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadHowToPlay()
    {
        SceneManager.LoadScene("HowToPlayScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadWin()
    {
        SceneManager.LoadScene("WinScene");
    }
    public void LoadLose()
    {
        SceneManager.LoadScene("LoseScene");
    }
}

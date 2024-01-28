using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    public GameObject cortinasAbrir;
    public GameObject cortinasFechar;

    public void LoadMainMenu()
    {
        if (cortinasAbrir != null)
        {
            cortinasAbrir.SetActive(false);

        }
        if (cortinasFechar != null)
        {
            cortinasFechar.SetActive(true);

        }
        Invoke("LoadDelayMainMenu", 3f);

    }
    private void LoadDelayMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadJokeLevelScene()
    {
        if (cortinasAbrir != null)
        {
            cortinasAbrir.SetActive(false);

        }
        if (cortinasFechar != null)
        {
            cortinasFechar.SetActive(true);

        }
        Invoke("LoadDelayJokeScene", 3f);
    }

    private void LoadDelayJokeScene()
    {
        SceneManager.LoadScene("JokeLevelScene");
    }

    public void LoadFamilyFriendlyGameScene()
    {
        if (cortinasAbrir != null)
        {
            cortinasAbrir.SetActive(false);

        }
        if (cortinasFechar != null)
        {
            cortinasFechar.SetActive(true);

        }
        Invoke("LoadDelayFamilyFriendly", 3f);
        
    }
    private void LoadDelayFamilyFriendly()
    {
        SceneManager.LoadScene("FamilyFriendlyGameScene"); ;
    }

    public void LoadNotFamilyFriendlyGameScene()
    {
        if (cortinasAbrir != null)
        {
            cortinasAbrir.SetActive(false);

        }
        if (cortinasFechar != null)
        {
            cortinasFechar.SetActive(true);

        }
        Invoke("LoadDelayNotFamilyFriendly", 3f);

    }
    private void LoadDelayNotFamilyFriendly()
    {
        SceneManager.LoadScene("NotFamilyFriendlyGameScene"); ;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}


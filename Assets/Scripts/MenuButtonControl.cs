using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadJokeLevelScene()
    {
        SceneManager.LoadScene("JokeLevelScene");
    }

    public void LoadFamilyFriendlyGameScene()
    {
        SceneManager.LoadScene("FamilyFriendlyGameScene");
    }

    public void LoadNotFamilyFriendlyGameScene()
    {
        SceneManager.LoadScene("NotFamilyFriendlyGameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

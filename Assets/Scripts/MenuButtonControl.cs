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
        // Invoke the LoadSceneDelayed method with a delay of 3 seconds
        Invoke("LoadSceneDelayed", 3f);
    }

    private void LoadSceneDelayed()
    {
        // This method will be called after the specified delay
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


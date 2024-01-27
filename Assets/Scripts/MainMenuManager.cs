using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Main Vars")]
    [SerializeField] string lightHumorSceneName;
    [SerializeField] string darkHumorSceneName;
    [Space]
    [SerializeField] GameObject humorSelectionWindow;
    [SerializeField] GameObject audioSettingsWindow;

    [Header("Main Menu Opening")]
    [SerializeField] float timerDuration = 5f;
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject OpenCurtains;
    [SerializeField] GameObject Curtains;

    [Header("Animations for main to humor")]
    [SerializeField] GameObject CloseCurtains;

    AudioSource buttonClick;

    void Start()
    {
        buttonClick = transform.GetComponent<AudioSource>();
        StartTimer();
    }

    void StartTimer()
    {
        Invoke("EnableGameObjectAfterTimer", timerDuration);
    }

    void EnableGameObjectAfterTimer()
    {
        // Enable the specified GameObject after the timer ends
        if (MainMenu != null)
        {
            MainMenu.SetActive(true);
        }
        if (OpenCurtains != null)
        {
            OpenCurtains.SetActive(true);
        }
        if (Curtains != null)
        {
            Curtains.SetActive(false);
        }
    }


    //Abrir menu de seleção de tipo de humor
    public void PlayButtonClick()
    {
        buttonClick.Play();
        CloseCurtains.SetActive(true);
        OpenCurtains.SetActive(false);

        // Start a coroutine to activate humorSelectionWindow after 1 second
        StartCoroutine(ActivateHumorSelectionWindowAfterDelay(1f));
    }

    IEnumerator ActivateHumorSelectionWindowAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        humorSelectionWindow.SetActive(true);
    }


    //Abrir menu de audio
    public void OpenAudioWindow()
    {
        buttonClick.Play();
        audioSettingsWindow.SetActive(true);
    }

    //Fechar menus
    public void BackButtonClick()
    {
        buttonClick.Play();
        humorSelectionWindow.SetActive(false);
        audioSettingsWindow.SetActive(false);
    }

    //Ir para cena de humor leve
    public void GoToLightHumorScene()
    {
        buttonClick.Play();
        Debug.Log("Ir para light humor");
        SceneManager.LoadScene(lightHumorSceneName);
    }

    //Ir para cena de humor negro
    public void GoToDarkHumor()
    {
        buttonClick.Play();
        Debug.Log("Ir para dark humor");
        SceneManager.LoadScene(darkHumorSceneName);
    }

    //Sair do jogo
    public void ExitGame()
    {
        buttonClick.Play();
        Debug.Log("Sair");
        Application.Quit();
    }
}




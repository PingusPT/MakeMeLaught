using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextSystemScript : MonoBehaviour
{

    public static TextSystemScript intance;

    [SerializeField] TextMeshProUGUI textMeshPro;

    [Header("Jokes")]
    public string[] Jokes;
    public string[] PunchLines;
    [Header("Variables")]
    public float typingSpeed = 0.05f;
    public int SpaceLines = 2;
    public float timeBetwenQuestions = 1f;
    string currentText = "";

    [SerializeField]
    Animator CanvasButoes;


    int CurrentJoke = 0;

    void Start()
    {
        intance = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            GetRandomJoke();
        }
    }
    public int ChooseRandomJoke()
    {
        return Random.Range(0, Jokes.Length - 1);
    }

    public IEnumerator TypeText(string fullText, TextMeshProUGUI textMeshPro, bool newString)
    {
        if(newString)
        {
            currentText = "";
        }
         

        foreach (char c in fullText)
        {
            currentText += c;
            textMeshPro.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(1f);

        ButonReciveScript.intance.GetCorrectAnswer();
        CanvasButoes.Play("ButtonAppear", 0, 0);
        if(newString)
        {
            yield return new WaitForSeconds(timeBetwenQuestions);
            GetRandomJoke();
        }
    }

    public void AddEnters(int spaces)
    {

        for (int i = 0; i < spaces; i++)
        {
            textMeshPro.text += "\n";
        }
    }

    public void AddPunchLine(string PunchLine)
    {
        StartCoroutine(TypeText(PunchLine, textMeshPro, false));
    }

    public void GetRandomJoke()
    {
        CurrentJoke = ChooseRandomJoke();
        StartCoroutine(TypeText(Jokes[CurrentJoke], textMeshPro, true));

    }

    public int GetCurrentJoke()
    {
        return CurrentJoke;
    }
}

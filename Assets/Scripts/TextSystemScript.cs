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
    [SerializeField]
    Animator PanelDeTexto;


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
            CanvasButoes.Play("ButtonAppear", 0, 0);
        }
         

        foreach (char c in fullText)
        {
            currentText += c;
            textMeshPro.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(1f);

        ButonReciveScript.intance.GetCorrectAnswer();
        
        if(!newString)
        {
            yield return new WaitForSeconds(10f);//timeBetwenQuestions
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAaa");
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
        PanelDeTexto.Play("PanelPiada", 0, 0);
        CurrentJoke = ChooseRandomJoke();
        StartCoroutine(TypeText(Jokes[CurrentJoke], textMeshPro, true));

    }

    public int GetCurrentJoke()
    {
        return CurrentJoke;
    }
}

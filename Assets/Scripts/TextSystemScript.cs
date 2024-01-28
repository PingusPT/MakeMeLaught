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
    public float timeBetwenQuestions = 4f;
    string currentText = "";

    [SerializeField]
    Animator CanvasButoes;
    [SerializeField]
    Animator PanelDeTexto;


    int CurrentJoke = 0;

    void Start()
    {
        intance = this;
        Invoke("GetRandomJoke", 5f);
       
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
        
        if(!newString)
        {
            yield return new WaitForSeconds(timeBetwenQuestions);//timeBetwenQuestions
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAaa");
            GetRandomJoke();
        }
        else
        {
            CanvasButoes.Play("ButtonAppear", 0, 0);
        }
    }

    public void AddEnters(int spaces)
    {
        currentText += "\n\n";
        textMeshPro.text = currentText;
       
       
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextSystemScript : MonoBehaviour
{

    public static TextSystemScript intance;

    private TextMeshProUGUI textMeshPro;

    [Header("Jokes")]
    public string[] Jokes;
    public string[] PunchLines;
    [Header("Variables")]
    public float typingSpeed = 0.05f;
    public int SpaceLines = 2;
    
    

    int CurrentJoke = 0;

    void Start()
    {
        intance = this;
        textMeshPro = GetComponent<TextMeshProUGUI>();
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

    public IEnumerator TypeText(string fullText, TextMeshProUGUI textMeshPro)
    {
        string currentText = "";

        foreach (char c in fullText)
        {
            currentText += c;
            textMeshPro.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(1f);

        ButonReciveScript.intance.GetCorrectAnswer();
    }

    private void AddEnters(int spaces)
    {

        for (int i = 0; i < spaces; i++)
        {
            textMeshPro.text += "\n";
        }
    }

    public void GetRandomJoke()
    {
        CurrentJoke = ChooseRandomJoke();
        StartCoroutine(TypeText(Jokes[CurrentJoke], textMeshPro));

    }

    public int GetCurrentJoke()
    {
        return CurrentJoke;
    }
}

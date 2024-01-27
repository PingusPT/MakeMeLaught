using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButonReciveScript : MonoBehaviour
{

    static public ButonReciveScript intance;

    [SerializeField] TextMeshProUGUI textMesh1, textMesh2, textMesh3;


    string[] answerButtons = { "", "", "" };



    float typingSpeed = .1f;
    int joke = 0;
    int saveJoke;
    bool Corect = false;


    void Start()
    {
        intance = this;
    }

    // Update is called once per frame
    public void GetCorrectAnswer()
    {
        Corect = false;

        joke = TextSystemScript.intance.GetCurrentJoke(); // Pega na joke certa


        saveJoke = Random.Range(0, 3);
        answerButtons[saveJoke] = TextSystemScript.intance.PunchLines[joke]; // save joke correta num sitio aleadorio guarda essa no SaveJoke
        int indexChanged = saveJoke;
        for (int i = 0; i < 3; i++) // Roda todos os butoes
        {

            if (i != saveJoke) // se o butao for o da resposta correta nao troca
            {

                int a = joke;
                while (joke == a || answerButtons[indexChanged] == answerButtons[i])
                {
                    Debug.Log(indexChanged);
                    a = Random.Range(0, TextSystemScript.intance.PunchLines.Length);
                    Debug.Log("times");
                    answerButtons[i] = TextSystemScript.intance.PunchLines[a];

                }
                indexChanged = i;
            }

        }


        StartCoroutine(TypeText(answerButtons[0], textMesh1));
        StartCoroutine(TypeText(answerButtons[1], textMesh2));
        StartCoroutine(TypeText(answerButtons[2], textMesh3));

    }

    public void Option1()
    {
        Corect = (saveJoke == 0) ? true : false;

    }

    public void Option2()
    {
        Corect = (saveJoke == 1) ? true : false;

    }

    public void Option3()
    {
        Corect = (saveJoke == 2) ? true : false;

    }

    public void IsCorrect()
    {
        if (Corect)
        {
            //Call animation Correct
        }
        else
        {
            //Call Wrong
        }
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
    }


}

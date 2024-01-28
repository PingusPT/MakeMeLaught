using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButonReciveScript : MonoBehaviour
{

    static public ButonReciveScript intance;

    [SerializeField] TextMeshProUGUI textMesh1, textMesh2, textMesh3;


    string[] answerButtons = { "", "", "" };


    [Header("velocidadeTexto")]
    [SerializeField]
    float typingSpeed = .1f;
    [SerializeField]
    int DamageforWrong = -1;
    [SerializeField]
    int HealForGood = 1;

    [SerializeField]
    Animator CanvasButoes;

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
        TextSystemScript.intance.AddEnters(2);
        TextSystemScript.intance.AddPunchLine(answerButtons[0]);
        Corect = (saveJoke == 0) ? true : false;
        IsCorrect();
    }

    public void Option2()
    {
        TextSystemScript.intance.AddEnters(2);
        TextSystemScript.intance.AddPunchLine(answerButtons[1]);
        Corect = (saveJoke == 1) ? true : false;
        IsCorrect();
    }

    public void Option3()
    {
        TextSystemScript.intance.AddEnters(2);
        TextSystemScript.intance.AddPunchLine(answerButtons[2]);
        Corect = (saveJoke == 2) ? true : false;
        IsCorrect();

    }

    public void IsCorrect()
    {
        if (Corect)
        {
            GameManagerScript.intance.ChangeHealth(HealForGood);
        }
        else
        {
            GameManagerScript.intance.ChangeHealth(DamageforWrong);
        }

        CanvasButoes.Play("ButtonDisapear", 0, 0);
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

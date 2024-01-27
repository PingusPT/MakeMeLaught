using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButonReciveScript : MonoBehaviour
{

    public static ButonReciveScript intance;

    [SerializeField] TextMeshProUGUI textMesh1, textMesh2, textMesh3;
    

    string[] answerButtons = {"","",""};

    

    float typingSpeed = .5f;
    int joke = 0;
    void Start()
    {
        intance = this;
    }

    // Update is called once per frame
    public void GetCorrectAnswer()
    {
        joke = TextSystemScript.intance.GetCurrentJoke(); // Pega na joke certa


        int saveJoke = Random.Range(0, 4);
        answerButtons[saveJoke] = TextSystemScript.intance.PunchLines[joke]; // save joke correta
        for (int i = 0; i < 3; i++)
        {
            if(i != saveJoke)
            {

            
                while (saveJoke == Random.Range(0, TextSystemScript.intance.PunchLines.Length - 1))
                {
                    answerButtons[] = TextSystemScript.intance.PunchLines[0, TextSystemScript.intance.PunchLines.Length - 1];
                }
            }
        }
        
    }
}
        


        /*
        for (int i = 0; i < 3; i++)
        {//        

            int flag = 0;
           while( answerButtons[i] == answerButtons[saveJoke]) // Escolhe joke para as outras  CUIDADO COM ESTA MERDA
           {
                if(answerButtons[saveJoke] == answerButtons[i])
                {
                    return;
                }
                answerButtons[i] = TextSystemScript.intance.PunchLines[Random.Range(0, TextSystemScript.intance.PunchLines.Length)];
                
                Debug.Log(answerButtons[i] + " |  " + answerButtons[saveJoke] + " !  "  + flag);
                flag++;
           }
        }
        */

        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i == correctButtonIndex)
            {
                // Se for o botão correto, use uma resposta do array de strings
                answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = punchLines[0]; // Supondo que o índice 0 contenha a resposta correta
            }
            else
            {
                // Se for outro botão, use uma punch line aleatória
                int randomIndex = Random.Range(1, punchLines.Length); // Evitando a resposta correta
                answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = punchLines[randomIndex];
            }

            // Adicione um listener de clique para cada botão
            int buttonIndex = i; // Precisamos disso para evitar o closure loop
            answerButtons[i].onClick.AddListener(() => ButtonClick(buttonIndex));
        }

        StartCoroutine(TypeText(answerButtons[0], textMesh1));
        StartCoroutine(TypeText(answerButtons[1], textMesh2));
        StartCoroutine(TypeText(answerButtons[2], textMesh3));

    }

    public void Option1()
    {
        
    }

    public void Option2()
    {
        
    }

    public void Option3()
    {
       
    }

    void ShuffleArray(string[] array)
    {
        // Algoritmo de embaralhamento Fisher-Yates
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            string temp = array[i];
            array[i] = array[j];
            array[j] = temp;
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

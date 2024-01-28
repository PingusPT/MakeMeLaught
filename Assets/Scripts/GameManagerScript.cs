using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    static public GameManagerScript intance;

    [Header("Values")]
    [SerializeField] float CorrectAnswers = 0;
    [SerializeField] float CorretasParaGanhar = 10;
    [SerializeField] int vidasDoZe = 5;
    [Space]
    [Header("Health Bar")]
    [SerializeField] Image heathBar;
    [Space]
    [Header("Ze dos Camiões")]
    [SerializeField]
    Animator animZe;
    [SerializeField]
    Animator Caminhoem;
    [SerializeField]
    Animator Roda1;
    [SerializeField]
    Animator Roda2;
    [SerializeField]
    Animator CanvasButoes;


    private void Start()
    {
        intance = this;
        heathBar.fillAmount = CorrectAnswers / CorretasParaGanhar; 
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CorrectAnswers >= CorretasParaGanhar)
        {

             SceneManager.LoadScene("WinScenarioFamilyFriendly");

        }
    }

    public void ChangeHealth(int valuevida)
    {
        if(valuevida < 0)
        {
            if(vidasDoZe == 0)
            {
                Caminhoem.SetTrigger("GoCar");
                Roda1.SetTrigger("GoRoda");
                Roda2.SetTrigger("GoRoda");
            }
            else
            {
                Invoke("DelayDamage", 1f);
                vidasDoZe--;
            }
            
        }
        else
        {
            CorrectAnswers += valuevida;
            heathBar.fillAmount = CorrectAnswers / CorretasParaGanhar;
        }
        
    }

    private void DelayDamage()
    {
        animZe.SetTrigger("TakeDamage");
    }
}

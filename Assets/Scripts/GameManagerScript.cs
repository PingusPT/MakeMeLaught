using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    static public GameManagerScript intance;

    [Header("Values")]
    [SerializeField] float CorrectAnswers = 0;
    [SerializeField] float CorretasParaGanhar = 10;
    [Space]
    [Header("Health Bar")]
    [SerializeField] Image heathBar;
    


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
            //Win
        }
    }

    public void ChangeHealth(int valuevida)
    {
        CorrectAnswers += valuevida;
        heathBar.fillAmount = CorrectAnswers / CorretasParaGanhar;
    }
}

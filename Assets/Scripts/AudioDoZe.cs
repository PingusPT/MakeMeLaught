using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDoZe : MonoBehaviour
{
    [SerializeField] AudioClip somFalar, SomBujas, SomFodase, SomOlhaAi, Tomate, FogoSom, AieSom, Pedrada, Facada, CAnnon;

    [SerializeField] Animator zeAnimator;

    [SerializeField] AudioSource odeFalar, oSfx;
    
    void Start()
    {
        odeFalar.clip = somFalar;
        odeFalar.loop = true;
        odeFalar.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = zeAnimator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Falar") || stateInfo.IsName("Falar 0") || stateInfo.IsName("Idle Pedrada 0") || stateInfo.IsName("Falar Facada") || stateInfo.IsName("Falar Balazio"))
        {
            odeFalar.Play();
        }
        else
        {
            odeFalar.Stop();
        }
    }

    private void FodaseClip()
    {
        oSfx.PlayOneShot(SomFodase);
    }

    private void BujasClip()
    {
        oSfx.PlayOneShot(SomBujas);
    }

    private void OlhaAIClip()
    {
        oSfx.PlayOneShot(SomOlhaAi);
    }

    private void TomateClip()
    {
        oSfx.PlayOneShot(Tomate);
    }

    private void AieClip()
    {
        oSfx.PlayOneShot(AieSom);
    }

    private void FogoClip()
    {
        oSfx.PlayOneShot(FogoSom);
    }

    private void PedradaClip()
    {
        oSfx.PlayOneShot(Pedrada);
    }

    private void FacadaClip()
    {
        oSfx.PlayOneShot(Facada);
    }

    private void CAnnonClip()
    {
        oSfx.PlayOneShot(CAnnon);
    }


}

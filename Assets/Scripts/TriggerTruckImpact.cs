using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTruckImpact : MonoBehaviour
{
    [SerializeField] GameObject Character;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("teste");
        Character.GetComponent<TesteAddForce>().forceApplied = false;
    }
}


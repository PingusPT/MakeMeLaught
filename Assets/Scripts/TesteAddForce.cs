using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TesteAddForce : MonoBehaviour
{
    [Header("Main Vars")]
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float impatctForce;
    [SerializeField] float impactTorque;

    public bool forceApplied = true;


    void FixedUpdate()
    {
        if (!forceApplied)
        {
            rb2d.AddForce(transform.right * impatctForce, ForceMode2D.Impulse);
            rb2d.AddTorque(impactTorque, ForceMode2D.Impulse);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokeLevelSceneLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objectsToEnable;

    [SerializeField]
    private GameObject[] objectsToDisable;

    private void Start()
    {
        // Delay execution by 2 seconds
        Invoke("EnableDisableObjects", 1.5f);
    }

    private void EnableDisableObjects()
    {
        // Enable objects
        foreach (GameObject obj in objectsToEnable)
        {
            if (obj != null)
                obj.SetActive(true);
        }

        // Disable objects
        foreach (GameObject obj in objectsToDisable)
        {
            if (obj != null)
                obj.SetActive(false);
        }
    }
}

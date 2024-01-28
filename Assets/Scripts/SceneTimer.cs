using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTime : MonoBehaviour
{
    public float sceneDuration = 5f; // Set the duration of the scene in seconds

    private float timer;

    void Start()
    {
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= sceneDuration)
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
       
        SceneManager.LoadScene("MainMenu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseWindow : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }
    
    public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public static void ToMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}

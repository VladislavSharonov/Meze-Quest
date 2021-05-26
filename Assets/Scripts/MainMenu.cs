using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool IsOpen = false;
    public GameObject window;

    private void Start()
    {
        window.SetActive(false);
    }

    public void Close()
    {
        window.SetActive(false);
        IsOpen = false;
    }
    
    public void Open()
    {
        window.SetActive(true);
        IsOpen = true;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("DemoLevel");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsOpen)
                QuitGame();
            else
                Open();
        }
    }
}

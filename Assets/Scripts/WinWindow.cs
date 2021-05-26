using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinWindow : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}

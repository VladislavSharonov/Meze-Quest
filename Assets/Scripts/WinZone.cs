using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    [SerializeField] private GameObject winUI;
    
    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0;
        winUI.SetActive(true);
    }
}

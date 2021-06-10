using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowMap : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hintsCountLabel = null;
    [SerializeField] private GameObject mapWindow = null;
    private void Awake()
    {
        if (mapWindow is null)
            Debug.LogException(new Exception("Map window is not set"));
        
        if (hintsCountLabel is null)
            Debug.LogException(new Exception("Show map hints label is not set"));
        
        UpdateLabel();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Tab) || Abilities.ShowMapCount <= 0) return;
        Abilities.ShowMapCount--;
        UpdateLabel();
        Instantiate(mapWindow);
    }

    private void UpdateLabel()
    {
        hintsCountLabel.text = $"x{Abilities.ShowMapCount}";
    }
}

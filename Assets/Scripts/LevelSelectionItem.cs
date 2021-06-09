using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionItem : MonoBehaviour
{
    [SerializeField] [Min(0f)] private int levelNumber = 1;
    [SerializeField] private Sprite preview = null;
    [SerializeField] private Vector2 mapSize = Vector2.zero;
    [SerializeField] private string coinCount = "0";
    [SerializeField] private Toggle toggle;
    [SerializeField] private Sprite activatedBackground = null;
    [SerializeField] private Sprite background = null;

    public int LevelNumber => levelNumber;

    public Sprite Preview => preview;

    public string Description
    {
        get => $"Размер карты: {mapSize.x}x{mapSize.y}\n" +
               $"Колличество монет: {coinCount}";
    }

    public void Activate()
    {
        toggle.image.sprite = activatedBackground;
    }

    public void Deactivate()
    {
        toggle.image.sprite = background;
    }
}

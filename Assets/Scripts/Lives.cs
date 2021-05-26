using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lives : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levesCountText;
    [SerializeField][Range(1, 5)] private readonly short defaultLivesCount = 3;
    private const short MaxLives = 100;
    private short livesCount;
    
    public short LivesCount
    {
        get => livesCount;
        set
        {
            livesCount = value;
            ChangeUILivesCount();
        }
    }

    public void Reset()
    {
        LivesCount = defaultLivesCount;
    }

    private void Start()
    {
        livesCount = defaultLivesCount;
    }

    private void ChangeUILivesCount()
    {
        levesCountText.text =  $"x{LivesCount}";
    }
}

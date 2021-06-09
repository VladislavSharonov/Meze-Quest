using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lable = null;
    
    const int Cost = 3;
    
    public void TryBuy()
    {
        if (CoinsSystem.Balance < Cost)
            return;
        
        CoinsSystem.WastCoins(Cost);
        Abilities.ShowMapCount++;
        if (lable != null)
            lable.text = $"x{Abilities.ShowMapCount}";
    }
}

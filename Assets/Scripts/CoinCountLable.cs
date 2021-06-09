using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCountLable : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI lable = null;
    void Start()
    {
        if (lable is null)
            Debug.LogAssertion("Lable is null");
        return;
        lable.text = CoinsSystem.Balance.ToString();
    }
}

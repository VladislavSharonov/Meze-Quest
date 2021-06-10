using TMPro;
using UnityEngine;

public class CoinCountLable : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI lable = null;
    private void Start()
    {
        if (lable is null)
        {            
            Debug.LogAssertion("Lable is null");
            return;
        }

        lable.text = CoinsSystem.Balance.ToString();
    }
    
    private void Update()
    {
        lable.text = CoinsSystem.Balance.ToString();
    }
}

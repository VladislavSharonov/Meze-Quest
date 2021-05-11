using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextHint : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }
}

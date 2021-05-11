using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyDoorSystem logic = null;

    private void Start()
    {
        if (logic is null)
            Debug.LogException(new Exception("KeyDoorSystem isn't set"));
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.transform.CompareTag("Player")) return;
        logic.TakeKey();
    }
}

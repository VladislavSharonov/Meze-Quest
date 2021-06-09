using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class DoorOpenZone : MonoBehaviour
{
    [SerializeField] private GameObject openHint = null;
    [SerializeField] private GameObject openIsNotAvailableHint = null;
    [SerializeField] private GameObject door;
    private void Start()
    {
        if (openHint is null)
            Debug.LogException(new Exception("Open hint wasn't set"));
        if (openIsNotAvailableHint is null)
            Debug.LogException(new Exception("Open isn't available hint wasn't set"));
        
        openHint.SetActive(false);
        openIsNotAvailableHint.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player));
        {
            if (player.IsKeyTaken)
                openHint.SetActive(true);
            else
                openIsNotAvailableHint.SetActive(true);
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        openHint.SetActive(false);
        openIsNotAvailableHint.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.TryGetComponent(out Player player)) return;
        if (!player.IsKeyTaken || !Input.GetKeyDown(KeyCode.E)) return;
        openHint.SetActive(false);
        Destroy(gameObject);
        Destroy(door);
    }
}

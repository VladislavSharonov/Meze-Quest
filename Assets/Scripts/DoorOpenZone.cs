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
    [SerializeField][FormerlySerializedAs("Key-Door System")] private KeyDoorSystem logic = null;
    
    private void Start()
    {
        if (logic is null)
            Debug.LogException(new Exception("GlobalLogic isn't set"));
        if (openHint is null)
            Debug.LogException(new Exception("Open hint wasn't set"));
        if (openIsNotAvailableHint is null)
            Debug.LogException(new Exception("Open isn't available hint wasn't set"));
        
        openHint.SetActive(false);
        openIsNotAvailableHint.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"));
        {
            if (logic.IsKeyTook)
                openHint.SetActive(true);
            else
                openIsNotAvailableHint.SetActive(true);
            Debug.Log("Enter the trigger");
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
        if (!other.CompareTag("Player")) return;
        if (!logic.IsKeyTook || !Input.GetKeyDown(KeyCode.E)) return;
        openHint.SetActive(false);
        logic.OpenDoor();
        gameObject.SetActive(false);
        Debug.Log("Stay the trigger");
    }
}

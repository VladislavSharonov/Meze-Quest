using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoorSystem : MonoBehaviour
{
    public void TakeKey()
    {
        Destroy(key);
        IsKeyTook = true;
    }

    public void OpenDoor()
    {
        Destroy(door);
    }
    
    [SerializeField] private GameObject key = null;
    [SerializeField] private GameObject door = null;

    private void Start()
    {
        if (key is null)
            Debug.LogException(new Exception("Key isn't set"));
        if (door is null)
            Debug.LogException(new Exception("Door isn't set"));
    }

    public bool IsKeyTook
    {
        get => _isKeyTook;
        private set
        {
            if (!value)
                Destroy(key);
            _isKeyTook = value;
        }
    }
    
    private bool _isKeyTook;
}

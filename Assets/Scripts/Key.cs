using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Key : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (!other.transform.TryGetComponent(out Player player)) return;
        Destroy(gameObject);
        player.IsKeyTaken = true;
    }
}

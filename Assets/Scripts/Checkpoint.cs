using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static Vector3? Current { get; private set; }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Player player)) return;
        var position = player.transform.position;
        Current = new Vector3(position.x, position.y, position.z);
    }
}

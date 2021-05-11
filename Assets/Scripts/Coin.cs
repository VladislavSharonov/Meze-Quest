using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private long denomination = 1;
    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private Vector3 rotationVector;
    [SerializeField] private float verticalAmplitude;
    [SerializeField] private float verticalSpeed;
    
    //[SerializeField] private AudioClip audioClip;

    private void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime * rotationVector);

        var verticalOffset = Mathf.Cos(Time.time * verticalSpeed) * verticalAmplitude * Time.deltaTime;
        transform.Translate(new Vector3(0f, verticalOffset, 0f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        //if (!(audioClip is null || TryGetComponent(out AudioSource audioSource)))
            //audioSource.PlayOneShot(audioClip);
            
        CoinsSystem.AddCoin(denomination);
        gameObject.SetActive(false);
    }
}

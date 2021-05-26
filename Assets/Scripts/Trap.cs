using System;
using System.Threading;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private GameObject loseWindow;
    //[SerializeField] private GameObject mesh;

    /*private void Start()
    {
        mesh.SetActive(false);
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Player player)) return;
        //mesh.SetActive(true);
        //Thread.Sleep(1100);
        player.TakeDamage();
        //mesh.SetActive(false);
    }
}

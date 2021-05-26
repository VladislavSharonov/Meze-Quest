using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private Lives lives;
    [SerializeField] private float speed = 3;
    [SerializeField] private float acceleration = 0.2f;
    [SerializeField] private float deceleration = 5f;
    [SerializeField] private new Camera camera;
    [SerializeField] private GameObject loseWindow;
    
    private Vector3 _statrtPosition;
    private Vector3 _moveDirection;
    private CharacterController _characterController;

    public bool IsKeyTook
    {
        get;
        set;
    }

    public void TakeDamage()
    {
        lives.LivesCount = (short) (lives.LivesCount - 1);
        if (lives.LivesCount <= 0 /*|| Checkpoint.Current is null*/)
        {
            Time.timeScale = 0f;
            lives.Reset();
            loseWindow.SetActive(true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
        else
        {
            //var position = Checkpoint.Current.Value;
            var oldGameObject = gameObject;
            Instantiate(gameObject, 
                        new Vector3(_statrtPosition.x, _statrtPosition.y, _statrtPosition.z), 
                        transform.rotation);
            gameObject.name = oldGameObject.name;
            Destroy(oldGameObject);
        }
    }

    private void Start()
    {
        _statrtPosition = gameObject.transform.position;
        _characterController = GetComponent<CharacterController>();
        if (_characterController is null)
            Debug.LogException(new Exception("GameObject has no CharacterController"));
        if (camera is null)
            Debug.LogWarning(new Exception("Camera is not set"));
        camera?.transform.LookAt(_characterController.transform.position);
    }

    private void Update()
    {
        if (Time.timeScale == 0)
            return;
        CharacterMove();
    }

    private void CharacterMove()
    {
        var moveVector = Vector3.zero;
        moveVector.x = -Input.GetAxis("Horizontal");
        moveVector.z = -Input.GetAxis("Vertical");
        moveVector.Normalize();
        if (IsDifferentDirection(_moveDirection.x, moveVector.x))
            _moveDirection.x = 0f;
        if (IsDifferentDirection(_moveDirection.z, moveVector.z))
            _moveDirection.z = 0f;

        if (moveVector != Vector3.zero)
        {
            _moveDirection = Vector3.Lerp(_moveDirection,
                                          moveVector,
                                          Time.deltaTime * Time.deltaTime * acceleration);
        }
        else
            _moveDirection = Vector3.Lerp(_moveDirection, Vector3.zero, Time.deltaTime * deceleration);
        
        if (_characterController.Move(_moveDirection * speed) == CollisionFlags.Sides)
            _moveDirection = Vector3.zero;
    }

    private static bool IsDifferentDirection(float a, float b) => b < 0 ^ a < 0 && a != 0 && b != 0;
}

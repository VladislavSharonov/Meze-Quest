using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] [Range(1, 5)] private short defaultLivesCount = 3;
    [SerializeField] private float speed = 3;
    [SerializeField] private float acceleration = 0.2f;
    [SerializeField] private float deceleration = 5f;
    [SerializeField] private new Camera camera;
    
    private Vector3 _moveDirection;
    private CharacterController _characterController;
    private const short MaxLives = 100;

    public bool IsKeyTook
    {
        get;
        set;
    }
    
    public int AddLives(short lives)
    {
        LivesCount += lives;
        if (LivesCount <= MaxLives) return 0;
        LivesCount %= 100;
        return LivesCount % 100;
    }

    public static short LivesCount
    {
        get;
        private set;
    }
    
    public void TakeDamage()
    {
        LivesCount--;
        if (LivesCount <= 0 || Checkpoint.Current is null)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        else
        {
            var position = Checkpoint.Current.Value;
            var oldGameObject = gameObject;
            Instantiate(gameObject, 
                        new Vector3(position.x, position.y, position.z), 
                        transform.rotation);
            gameObject.name = oldGameObject.name;
            Destroy(oldGameObject);
        }
    }

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        if (_characterController is null)
            Debug.LogException(new Exception("GameObject has no CharacterController"));
        if (camera is null)
            Debug.LogWarning(new Exception("Camera is not set"));
        camera?.transform.LookAt(_characterController.transform.position);
        
        if (LivesCount <= 0)
            LivesCount = defaultLivesCount;
    }

    private void Update()
    {
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

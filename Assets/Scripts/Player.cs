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
    [SerializeField] private Vector2 acceleration = new Vector2(.2f, .2f);
    [SerializeField] private Vector2 deceleration = new Vector2(1f, 1f);
    [SerializeField] private new Camera camera;
    [SerializeField] private GameObject loseWindow;
    [SerializeField] private float startSpeed = 1f;
    
    private Vector3 statrtPosition;
    //private Vector3 moveDirection;
    private CharacterController characterController;
    private Vector2 currentSpeed = Vector2.one;

    public int TakenCoinsCount { get; set; }
    
    public bool IsKeyTaken
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
                        new Vector3(statrtPosition.x, statrtPosition.y, statrtPosition.z), 
                        transform.rotation);
            gameObject.name = oldGameObject.name;
            Destroy(oldGameObject);
        }
    }

    private void Start()
    {
        statrtPosition = gameObject.transform.position;
        characterController = GetComponent<CharacterController>();
        if (characterController is null)
            Debug.LogException(new Exception("GameObject has no CharacterController"));
        if (camera is null)
            Debug.LogWarning(new Exception("Camera is not set"));
        camera?.transform.LookAt(characterController.transform.position);
    }

    private void Update()
    {
        if (Time.timeScale == 0)
            return;
        CharacterMove();
    }

    private void CharacterMove()
    {
        var moveDirection = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        /*if (moveDirection.x > moveDirection.z)
            moveDirection.z = 0f;
        else
            moveDirection.x = 0f;*/
        
        /*currentSpeed.x = ComputeCurrentSpeed(currentSpeed.x, acceleration.x, moveDirection.x != 0f);
        currentSpeed.y = ComputeCurrentSpeed(currentSpeed.y, acceleration.y, moveDirection.z != 0f);
        
        moveDirection.x *= currentSpeed.x * currentSpeed.x;
        moveDirection.z *= currentSpeed.y * currentSpeed.y;*/
        currentSpeed.x = ComputeCurrentSpeed(currentSpeed.x, acceleration.x, moveDirection.x != 0f);
        currentSpeed.y = ComputeCurrentSpeed(currentSpeed.y, acceleration.y, moveDirection.z != 0f);
        moveDirection.x *= (float)Math.Sqrt(currentSpeed.x);
        moveDirection.z *= (float)Math.Sqrt(currentSpeed.y);

        characterController.SimpleMove(moveDirection);
    }

    private float ComputeCurrentSpeed(float currentSpeed, float acceleration, bool isMoveByThisAxis)
    {
        currentSpeed = isMoveByThisAxis ? currentSpeed + Time.deltaTime * acceleration : 0f;
        if (currentSpeed > speed)
            currentSpeed = speed;

        return currentSpeed;
    }
    
    // private static bool IsDifferentDirection(float a, float b) => b < 0 ^ a < 0 && a != 0 && b != 0;
}

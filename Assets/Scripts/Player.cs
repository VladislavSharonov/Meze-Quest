using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private Lives lives;
    [SerializeField] private float speed = 3;
    [SerializeField] private Vector2 acceleration = new Vector2(.2f, .2f);
    //[SerializeField] private Vector2 deceleration = new Vector2(1f, 1f);
    [SerializeField] private GameObject loseWindow;
    [SerializeField] private Camera playerCamera;
    
    private Vector3 startPosition;
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
        if (lives.LivesCount <= 0)
        {
            Time.timeScale = 0f;
            lives.Reset();
            loseWindow.SetActive(true);
        }
        else
        {
            var oldGameObject = gameObject;
            Instantiate(gameObject, 
                        new Vector3(startPosition.x, startPosition.y, startPosition.z), 
                        transform.rotation);
            gameObject.name = oldGameObject.name;
            Destroy(oldGameObject);
        }
    }

    private void Start()
    {
        startPosition = gameObject.transform.position;
        characterController = GetComponent<CharacterController>();
        if (characterController is null)
            Debug.LogException(new Exception("GameObject has no CharacterController"));
        
        playerCamera.transform.LookAt(characterController.transform.position);
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
        currentSpeed.x = ComputeCurrentSpeed(currentSpeed.x, acceleration.x, moveDirection.x != 0f);
        currentSpeed.y = ComputeCurrentSpeed(currentSpeed.y, acceleration.y, moveDirection.z != 0f);
        moveDirection.x *= (float)Math.Sqrt(currentSpeed.x);
        moveDirection.z *= (float)Math.Sqrt(currentSpeed.y);

        characterController.SimpleMove(moveDirection);
    }

    private float ComputeCurrentSpeed(float currentSpeedForAxis, float accelerationForAxis, bool isMoveByThisAxis)
    {
        currentSpeedForAxis = isMoveByThisAxis ? currentSpeedForAxis + Time.deltaTime * accelerationForAxis : 0f;
        if (currentSpeedForAxis > speed)
            currentSpeedForAxis = speed;

        return currentSpeedForAxis;
    }
}

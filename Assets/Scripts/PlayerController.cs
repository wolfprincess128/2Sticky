using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private InputActionReference moveAction;
   [SerializeField] private InputActionReference lookAction;
   [SerializeField] private InputActionReference slowAction;
   Vector2 moveInput;
   Vector2 lookInput;

   public bool isSpeedEffect;
   [SerializeField] private float baseSpeed;
   private float speedMultiplier;
   private Rigidbody playerBody;

   Transform playerMove;
   Vector3 playerPos;
   private void OnEnable()
   {
    moveAction.action.Enable();
    lookAction.action.Enable();
    slowAction.action.Enable();
   }
      private void OnDisable()
   {
    moveAction.action.Disable();
    lookAction.action.Disable();
    slowAction.action.Disable();
   }

    void Start()
    {
        playerMove = this.gameObject.GetComponent<Transform>();
        playerBody = GetComponent<Rigidbody>();
        baseSpeed = 7f;
    }
    void FixedUpdate()
    {
      Vector2 direction = moveInput;
      float speed = baseSpeed * speedMultiplier;

      playerBody.linearVelocity = new Vector3(
        direction.x * speed,
        playerBody.linearVelocity.y,
        direction.y * speed
      );  
    }
    void Update()
    {
        moveInput = moveAction.action.ReadValue<Vector2>();
        lookInput = lookAction.action.ReadValue<Vector2>();
        
        HandleSpeed();

        Vector2 direction = -lookInput;

        if (lookAction.action.activeControl?.device is Mouse)
        {
            Vector2 playerOnScreen = Camera.main.WorldToScreenPoint(transform.position);
            direction =  playerOnScreen - Mouse.current.position.ReadValue();
        }
        if (direction.sqrMagnitude > 0.05f)
        {
            transform.forward = new Vector3(direction.y, 0f, -direction.x);
        }

    }

        void HandleSpeed()
    {
        if (slowAction.action.IsPressed())
        { 
            speedMultiplier = 0.5f;
        }
        else if (isSpeedEffect)
        {
            speedMultiplier = 2f;
        }
        else
        {
            speedMultiplier = 1f;
        }
    }
}



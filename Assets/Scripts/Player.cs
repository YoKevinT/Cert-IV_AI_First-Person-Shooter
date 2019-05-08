using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float runSpeed = 16f;
    public float walkSpeed = 6f;
    public float gravity = -18f;
    public LayerMask groundLayer;
    //public float crouchSpeed = 2f;
    public float jumpHeight = 8f;
    public float groundRayDistance = 1.1f;

    private CharacterController controller;
    private Vector3 motion;
    private bool isJumping = false;
    private float currentSpeed;

    void Start()
    { // Scope
        controller = GetComponent<CharacterController>();
        currentSpeed = walkSpeed;
    }

    void Update()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        bool inputSprint = Input.GetButton("Sprint");
        bool inputJump = Input.GetButtonDown("Jump");

        // Normalizing movement
        Vector3 normalized = new Vector3(inputH, 0f, inputV);
        normalized.Normalize();

        if (inputSprint)
        {
            Sprint();
        }

        Move(normalized.x, normalized.y);

        // Without normalizing
        // Move(inputH, inputV);

        // If Jump button pressed (Space)
        if (IsGrounded() && inputJump)
        {
            // Make character jump
            Jump(jumpHeight);
        }

        // If Is Grounded AND is NOT jumping
        if (IsGrounded() && !isJumping)
        {
            motion.y = 0f;
        }

        motion.y += gravity * Time.deltaTime;

        // If NOT Grounded anymore AND is jumping
        if (!IsGrounded() && isJumping)
        {
            isJumping = false;
        }

        motion.y += gravity * Time.deltaTime;

        // Applies motion to CharacterController
        controller.Move(motion * Time.deltaTime);
    }

    // Test if the Player is Grounded
    private bool IsGrounded()
    {
        /// Alternative (1 Line of code)
        /// return Physics.Raycast (new Ray(transform.position, -transform.up), groundRayDistance);
        Ray groundRay = new Ray(transform.position, -transform.up);
        // Performing Raycast
        if (Physics.Raycast(groundRay, groundRayDistance, groundLayer))
        {
            // Return true is hit
            return true; // - Exits the function
        }
        // Return false if not hit
        return false; // - Exits the function
    }

    // Move the Player Character in the direction we give it (horizontal / vertical)
    public void Move(float inputH, float inputV)
    {
        Vector3 direction = new Vector3(inputH, 0f, inputV);

        // Convert local direction to world space
        direction = transform.TransformDirection(direction);

        motion.x = direction.x * currentSpeed;
        motion.z = direction.z * currentSpeed;
    }

    public void Sprint()
    {
        currentSpeed = runSpeed;
    }

    public void Walk()
    {
        currentSpeed = walkSpeed;
    }

    // Make the player jump when called
    public void Jump(float height)
    {
        motion.y = jumpHeight;
        isJumping = true;
    }

}
/*
   public float runSpeed = 8f;
   public float walkSpeed = 6f;
   public float gravity = 10f;
   public float crouchSpeed = 2f;
   public float jumpHeight = 15f;
   public float groundRayDistance = 1.1f;
 
  public static bool canMove;
  private CharacterController Controller;
  public Vector3 moveDirection;

  // Start is called before the first frame update
  void Start()
  {
      canMove = true;
      //charc is on this game object we need to get the character controller that is attached to it
      Controller = this.GetComponent<CharacterController>();
  }

  // Update is called once per frame
  void Update()
  {
      if (canMove)
      {
          //if player is grounded
          //we are able to move in game scene meaning
          if (Controller.isGrounded)
          {
              //moveDir is equal to a new vector3 that is affected by Input.Get Axis.. Horizontal, 0, Vertical
              moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
              //moveDir is transformed in the direction of our moveDir
              moveDirection = transform.TransformDirection(moveDirection);
              //our moveDir is then multiplied by our walkspeed
              moveDirection *= walkSpeed;
          }

          //if we press left shift run
          if (Input.GetKey(KeyCode.LeftShift))
          {
              walkSpeed = runSpeed;
          }

          //else if we press control shift cround
          else if (Input.GetKey(KeyCode.LeftControl))
          {
              walkSpeed = crouchSpeed;
          }

          else
          {
              walkSpeed = 6f;
          }

          //regardless of if we are grounded or not the players moveDir.y is always affected by gravity timesed by time.deltaTime to normalize it
          moveDirection.y -= gravity * Time.deltaTime;
          //we then tell the character Controller that it is moving in a direction timesed Time.deltaTime
          Controller.Move(moveDirection * Time.deltaTime);
      }
  }
}
*/

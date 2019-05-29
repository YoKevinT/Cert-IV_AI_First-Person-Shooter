/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
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
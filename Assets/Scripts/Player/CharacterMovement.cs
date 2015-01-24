using UnityEngine;
using System.Collections;

/// <summary>
/// Character movement.
/// 
/// Add this script to the "Player" GameObject.
/// </summary>

public class CharacterMovement : MonoBehaviour 
{
	private float speed = 2.0f;
	private float jumpSpeed = 0.0f;		// Jumping disabled for now (value 0.0f)
	private float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;

	private GameObject player;
	private CharacterController controller;


	void Awake ()
	{
		controller = GameObject.Find("Capsule_player").GetComponent<CharacterController>();
	}

	void Update () 
	{
		MoveCharacter();
	}

//=================================================================================================================

	/// <summary>
	/// Moves the character.
	/// </summary>
	void MoveCharacter ()
	{
		if (controller.isGrounded)
		{
			// Feed moveDirection with input.
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			
			// Multiply it by speed.
			moveDirection *= speed;
/*			
			// Jumping
			if (Input.GetButton("Jump"))
			{
				moveDirection.y = jumpSpeed;
			}
*/
		}

		// Applying gravity to the controller
		moveDirection.y -= gravity * Time.deltaTime;
		
		// Making the character move
		controller.Move(moveDirection * Time.deltaTime);
	}

}

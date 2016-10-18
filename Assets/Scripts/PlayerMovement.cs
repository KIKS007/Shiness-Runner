using UnityEngine;
using System.Collections;
using Rewired;
using DG.Tweening;

public enum JumpState {Grounded, CanDoubleJump, InAir};

public class PlayerMovement : MonoBehaviour 
{
	public Player controller;

	[Header ("Movement")]
	public float movementSpeed = 10f;

	[Header ("Jump")]
	public JumpState jumpState = JumpState.Grounded;
	public LayerMask wallLayer;
	public float groundedRayLength = 0.2f;
	public float jumpForce = 15f;
	public float doubleJumpForce = 20f;
	public float gravityForce = 40f;


	private Rigidbody rigidBody;

	private float distToGround;

	// Use this for initialization
	void Start () 
	{
		controller = ReInput.players.GetPlayer (0);
		rigidBody = GetComponent <Rigidbody> ();
		distToGround = GetComponent <Collider> ().bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetInput ();
	}

	void FixedUpdate () 
	{
		Gravity ();
	}

	void GetInput ()
	{
		if(controller.GetButtonDown ("Jump"))
		{
			switch(jumpState)
			{
			case JumpState.Grounded:
				jumpState = JumpState.CanDoubleJump;
				Jump ();
				break;
			case JumpState.CanDoubleJump:
				jumpState = JumpState.InAir;
				DoubleJump ();
				break;
			case JumpState.InAir:
				break;
			}
		}
	}

	void Gravity ()
	{
		rigidBody.AddForce (new Vector3(0, -gravityForce, 0), ForceMode.Force);
	}

	void Jump ()
	{
		rigidBody.AddForce (new Vector3(0, jumpForce, 0), ForceMode.Impulse);
	}

	void DoubleJump ()
	{
		rigidBody.AddForce (new Vector3(0, doubleJumpForce, 0), ForceMode.Impulse);
	}

	void OnCollisionEnter (Collision collision)
	{
		Debug.Log (collision.collider.gameObject.layer);

		if (collision.gameObject.layer == wallLayer)
		{
			Debug.Log (collision.collider);
			Debug.Log (IsGrounded ());
		}

		if (collision.gameObject.layer == wallLayer && IsGrounded ())
		{
			
			jumpState = JumpState.Grounded;
		}
	}

	public bool IsGrounded ()
	{
		Vector3 position = transform.position;

		//return Physics.Raycast (transform.position, -Vector3.up, distToGround + groundedRayLength);

		if(Physics.Raycast (new Vector3(position.x, position.y, position.z), -Vector3.up, distToGround + groundedRayLength))
			return true;

		else if(Physics.Raycast (new Vector3(position.x - 0.3f, position.y, position.z), -Vector3.up, distToGround - 0.1f + groundedRayLength))
			return true;

		else if(Physics.Raycast (new Vector3(position.x + 0.3f, position.y, position.z), -Vector3.up, distToGround - 0.1f + groundedRayLength))
			return true;

		else if(Physics.Raycast (new Vector3(position.x, position.y, position.z - 0.3f), -Vector3.up, distToGround - 0.1f + groundedRayLength))
			return true;

		else if(Physics.Raycast (new Vector3(position.x, position.y, position.z + 0.3f), -Vector3.up, distToGround - 0.1f + groundedRayLength))
			return true;

		else
			return false;
	}

	void IsGroundedDebug ()
	{
		Vector3 direction = transform.position;

		Debug.DrawRay(new Vector3(direction.x, direction.y, direction.z), new Vector3(0, -distToGround - groundedRayLength, 0), Color.red);
		Debug.DrawRay(new Vector3(direction.x - 0.3f, direction.y, direction.z), new Vector3(0, -distToGround + 0.1f - groundedRayLength, 0), Color.red);
		Debug.DrawRay(new Vector3(direction.x + 0.3f, direction.y, direction.z), new Vector3(0, -distToGround + 0.1f - groundedRayLength, 0), Color.red);
		Debug.DrawRay(new Vector3(direction.x, direction.y, direction.z - 0.3f), new Vector3(0, -distToGround + 0.1f - groundedRayLength, 0), Color.red);
		Debug.DrawRay(new Vector3(direction.x, direction.y, direction.z + 0.3f), new Vector3(0, -distToGround + 0.1f - groundedRayLength, 0), Color.red);
	}
}

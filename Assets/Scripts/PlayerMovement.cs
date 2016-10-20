using UnityEngine;
using System.Collections;
using Rewired;
using DG.Tweening;
using System;

public enum JumpState {Grounded, Jumping, Falling};

public class PlayerMovement : MonoBehaviour 
{
	public Player controller;

	[Header ("Top Movement")]
	public float topMovementSpeed = 10f;

	[Header ("Side Movement")]
	public float sideMovementSpeed = 10f;

	[Header ("Side Jump")]
	public JumpState jumpState = JumpState.Grounded;
	public float jumpDuration;
	public float maxJumpDuration;
	public float minJumpForce = 15f;
	public float jumpForce = 15f;
	//public float doubleJumpForce = 20f;

	[Header ("Grounded")]
	public LayerMask wallLayer;
	public float groundedRayLength = 0.2f;
	public float gravityForce = 40f;


	private Rigidbody rigidBody;

	private float distToGround;

	private GameObject mainCamera;

	private Transform poui;

	private CameraSwitchView cameraSwitchScript;

	// Use this for initialization
	void Start () 
	{
		controller = ReInput.players.GetPlayer (0);
		rigidBody = GetComponent <Rigidbody> ();
		distToGround = GetComponent <Collider> ().bounds.extents.y;
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		cameraSwitchScript = mainCamera.GetComponent <CameraSwitchView> ();
		poui = GameObject.FindGameObjectWithTag ("Poui").transform;
		GameManager.Instance.OnSideView += DebugMovement;

	}

	void DebugMovement ()
	{
		enabled = false;
		enabled = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GameManager.Instance.gameState == GameState.Playing)
		{
			GetCommonInput ();
			
			if(GameManager.Instance.viewState == ViewState.Side)
				GetSideInput ();			
		}

		Debug.Log (transform.position.z);
	}

	void FixedUpdate () 
	{
		Gravity ();

		if(GameManager.Instance.gameState == GameState.Playing)
		{
			
			if(GameManager.Instance.viewState == ViewState.Top)
				TopMovement ();
			

			if(GameManager.Instance.viewState == ViewState.Side)
				SideMovement ();
			
		}
	}

	void Gravity ()
	{
		rigidBody.AddForce (new Vector3(0, -gravityForce, 0), ForceMode.Force);
	}

	void TopMovement ()
	{
		rigidBody.constraints = RigidbodyConstraints.FreezeRotation;

		Vector3 target = poui.position - transform.position;
		target.y = 0;
		target.Normalize ();

		if (cameraSwitchScript.isMovingAlongPath)
			target = new Vector3 (mainCamera.transform.position.x - transform.position.x, 0, 0);

		target *= topMovementSpeed + Vector3.Distance (transform.position, poui.position);

		rigidBody.MovePosition (transform.position + target * Time.fixedDeltaTime);
	}

	void SideMovement ()
	{
		rigidBody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

		rigidBody.MovePosition (transform.position + new Vector3(sideMovementSpeed * Time.fixedDeltaTime, 0, 0));

		if (transform.position.z != 0)
			transform.DOLocalMoveZ (0, 1);
	}

	void GetCommonInput ()
	{
		if(controller.GetButtonDown ("SwitchView"))
		{
			if (GameManager.Instance.viewState == ViewState.Top)
				mainCamera.GetComponent <CameraSwitchView> ().TopSide ();

			else
				mainCamera.GetComponent <CameraSwitchView> ().ToTop ();
		}
	}

	void GetSideInput ()
	{
		if (controller.GetButtonDown ("Jump") && jumpState == JumpState.Grounded)
		{
			jumpDuration = 0;
			jumpState = JumpState.Jumping;
			rigidBody.velocity = new Vector3(rigidBody.velocity.x, minJumpForce, rigidBody.velocity.z);
			StartCoroutine (SideJump ());
		}


	}

	IEnumerator SideJump ()
	{
		while(controller.GetButton ("Jump") && jumpDuration < maxJumpDuration)
		{
			jumpDuration = controller.GetButtonTimePressed ("Jump");
			rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpForce, rigidBody.velocity.z);
			yield return null;
		}

		jumpState = JumpState.Falling;
	}

	void OnCollisionEnter (Collision collision)
	{
		if ((1<<collision.gameObject.layer) == wallLayer)
			jumpState = JumpState.Grounded;
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
}

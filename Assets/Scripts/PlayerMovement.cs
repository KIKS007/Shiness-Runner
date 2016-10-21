using UnityEngine;
using System.Collections;
using Rewired;
using DG.Tweening;
using System;

public enum JumpState {Grounded, Jumping, Falling};

public class PlayerMovement : MonoBehaviour 
{
	public event EventHandler OnHit;
	public event EventHandler OnDeath;
	public event EventHandler Running;
	public event EventHandler OnKick;
	public event EventHandler OnJumpStart;
	public event EventHandler Jumping;
	public event EventHandler OnJumpEnd;
	public event EventHandler Falling;

	public Player controller;

	[Header ("Top Movement")]
	public float topMovementSpeed = 10f;

	[Header ("Side Movement")]
	public float sideMovementSpeed = 10f;

	[Header ("Hit & Reset Scroll")]
	public float hitSpeed;
	public bool hitTest = false;
	public float hitForce = 2;
	public float hitDelay = 2;
	public float speedAdded = 2;

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

	[Header ("Gravity")]
	public float gravityForce = 40f;
	public float gravityForceHit = 40f;


	private Rigidbody rigidBody;

	private float distToGround;

	private GameObject mainCamera;

	private Transform poui;

	//private CameraSwitchView cameraSwitchScript;

	public bool reseting = false;

	// Use this for initialization
	void Start () 
	{
		controller = ReInput.players.GetPlayer (0);
		rigidBody = GetComponent <Rigidbody> ();
		distToGround = GetComponent <Collider> ().bounds.extents.y;
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		//cameraSwitchScript = mainCamera.GetComponent <CameraSwitchView> ();
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

			if(hitTest)
			{
				hitTest = false;

				Hit ();
			}	
		}
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

		if(jumpState == JumpState.Falling)
		{
			if (Falling != null)
				Falling ();
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


		Vector3 pouiTarget = poui.position;
		pouiTarget.y = transform.position.y;

		transform.LookAt (pouiTarget);


		target *= reseting ? hitSpeed : topMovementSpeed;

		if(IsGrounded ())
		{
			if (Running != null)
				Running ();			
		}

		rigidBody.MovePosition (transform.position + target * Time.fixedDeltaTime);
	}

	void SideMovement ()
	{
		rigidBody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

		float speed = reseting ? hitSpeed : sideMovementSpeed;

		if(IsGrounded ())
		{
			if (Running != null)
				Running ();			
		}

		rigidBody.MovePosition (transform.position + new Vector3(speed * Time.fixedDeltaTime, 0, 0));

		if (transform.position.z != 0)
		{
			if(DOTween.IsTweening ("LocalMoveZ"))
				DOTween.Kill ("LocalMoveZ");
			
			transform.DOLocalMoveZ (0, 1).SetId ("LocalMoveZ");
		}
	}

	void GetCommonInput ()
	{
		if(controller.GetButtonDown ("SwitchView"))
		{
			if (GameManager.Instance.viewState == ViewState.Top)
				mainCamera.GetComponent <CameraSwitchView> ().ToSide ();

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

			if (OnJumpStart != null)
				OnJumpStart ();	

			rigidBody.velocity = new Vector3(rigidBody.velocity.x, minJumpForce, rigidBody.velocity.z);
			StartCoroutine (SideJump ());
		}


	}

	IEnumerator SideJump ()
	{
		while(controller.GetButton ("Jump") && jumpDuration < maxJumpDuration)
		{
			jumpDuration = controller.GetButtonTimePressed ("Jump");

			if (Jumping != null)
				Jumping ();	

			rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpForce, rigidBody.velocity.z);
			yield return null;
		}

		if (OnJumpEnd != null)
			OnJumpEnd ();	

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

	public void Hit ()
	{
		reseting = false;
		StopCoroutine (WaitReset ());
		StopCoroutine (ResetScrollPlayer ());
	
		if(jumpState != JumpState.Grounded)
			StartCoroutine (AddGravity ());

		if (OnHit != null)
			OnHit ();
		
		rigidBody.AddForce (-Vector3.right * hitForce, ForceMode.Impulse);

		StartCoroutine (WaitReset ());
	}

	IEnumerator WaitReset ()
	{
		yield return new WaitForSeconds (hitDelay);

		StartCoroutine (ResetScrollPlayer ());
	}

	IEnumerator ResetScrollPlayer ()
	{
		reseting = true;
		
		if(GameManager.Instance.viewState == ViewState.Top)
		{
			hitSpeed = topMovementSpeed;
			hitSpeed += speedAdded;
		}
		else
		{
			hitSpeed = sideMovementSpeed;
			hitSpeed += speedAdded;
		}
		
		yield return new WaitWhile (()=> Mathf.Abs (mainCamera.transform.parent.position.x - transform.position.x) > 0.3f);
		
		reseting = false;		

	}

	IEnumerator AddGravity ()
	{
		do
		{
			rigidBody.AddForce (new Vector3(0, -gravityForceHit, 0), ForceMode.Force);

			yield return new WaitForFixedUpdate ();

		} while (jumpState != JumpState.Grounded);
	}

	public void DeathEvent ()
	{
		if (OnDeath != null)
			OnDeath ();
	}

	public void KickEvent ()
	{
		if (OnKick != null)
			OnKick ();
	}
}

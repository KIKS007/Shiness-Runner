using UnityEngine;
using System.Collections;

public class PlayerAnimations : MonoBehaviour 
{
	public Animator anim;

	private PlayerMovement playerScript;

	// Use this for initialization
	void Start () 
	{
		playerScript = GetComponent <PlayerMovement> ();

		playerScript.OnJumpStart += JumpStart;
		playerScript.OnJumpEnd += JumpEnd;
		playerScript.OnKick += Kick;
		playerScript.OnHit += Hit;
		playerScript.OnDeath += Death;
	}
	
	// Update is called once per frame
	void Update () 
	{
		anim.SetBool ("Grounded", playerScript.IsGrounded ());
	}

	void JumpStart ()
	{
		anim.SetTrigger ("Jump_Start");
	}

	void JumpEnd ()
	{
		anim.SetTrigger ("Jump_End");

	}

	void Kick ()
	{
		anim.SetTrigger ("Kick");

	}

	void Hit ()
	{
		anim.SetTrigger ("Hit");

	}

	void Death ()
	{
		anim.SetTrigger ("Death");

	}
}

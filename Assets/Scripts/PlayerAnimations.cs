﻿using UnityEngine;
using System.Collections;

public class PlayerAnimations : MonoBehaviour 
{
	private Animator anim;

	public float topRunningSpeed;
	public float sideRunningSpeed;

	private PlayerMovement playerScript;

	// Use this for initialization
	void Start () 
	{
		anim = GameObject.FindGameObjectWithTag ("PlayerAnimator").GetComponent <Animator> ();

		playerScript = GetComponent <PlayerMovement> ();

		playerScript.OnJumpStart += JumpStart;
		playerScript.OnJumpEnd += JumpEnd;
		playerScript.OnKick += Kick;
		playerScript.OnHit += Hit;
		playerScript.OnDeath += Death;

		GameManager.Instance.OnTopView += TopSpeed;
		GameManager.Instance.OnSideView += SideSpeed;
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

	void TopSpeed ()
	{
		anim.SetFloat ("RunMultiplier", topRunningSpeed);
	}

	void SideSpeed ()
	{
		anim.SetFloat ("RunMultiplier", sideRunningSpeed);
	}
}
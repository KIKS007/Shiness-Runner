using UnityEngine;
using System.Collections;
using Rewired;

public class PlayerAttack : MonoBehaviour 
{
	public Player controller;
	public enum AttackState{CanAttack, Attacking, Cooldown};

	public AttackState attackState = AttackState.CanAttack;

	public float attackDuration = 2;
	public float attackCooldown = 2;

	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () 
	{
		controller = ReInput.players.GetPlayer (0);
		rigidBody = GetComponent <Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(controller.GetButtonDown ("Attack") && attackState == AttackState.CanAttack)
		{
			attackState = AttackState.Attacking;
			StartCoroutine (Attack ());
		}
	}

	IEnumerator Attack ()
	{
		yield return new WaitForSeconds (attackDuration);

		attackState = AttackState.Cooldown;

		yield return new WaitForSeconds (attackCooldown);

		attackState = AttackState.CanAttack;
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.tag == "Enemy" && attackState == AttackState.Attacking)
		{
			KillEnemy (other.gameObject);
		}
	}

	void KillEnemy (GameObject enemy)
	{
		Destroy (enemy);
		Debug.Log ("Enemy killed");
	}
}

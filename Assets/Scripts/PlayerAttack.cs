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

	private GameObject attackTrigger;

	// Use this for initialization
	void Start () 
	{
		controller = ReInput.players.GetPlayer (0);
		attackTrigger = transform.GetChild (0).gameObject;
		attackTrigger.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(controller.GetButtonDown ("Attack") && attackState == AttackState.CanAttack && GameManager.Instance.viewState == ViewState.Top)
		{
			StartCoroutine (Attack ());
		}
	}

	IEnumerator Attack ()
	{
		attackState = AttackState.Attacking;

		attackTrigger.SetActive (true);

		yield return new WaitForSeconds (attackDuration);

		attackTrigger.SetActive (false);

		attackState = AttackState.Cooldown;

		yield return new WaitForSeconds (attackCooldown);

		attackState = AttackState.CanAttack;
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "Enemy" && attackState == AttackState.Attacking)
		{
			Debug.Log (other.GetComponent<Collider>());
			KillEnemy (other.gameObject);
		}
	}

	void KillEnemy (GameObject enemy)
	{
		Destroy (enemy);
		Debug.Log ("Enemy killed");
	}
}

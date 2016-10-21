using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public bool chasingPlayer = false;
	public float speed;
	public float punchForce;
	public float delayAfterPunch;

	private Transform player;

	private Rigidbody rigidBody;

	private bool isDelayed = false;

	private Animator anim;

	// Use this for initialization
	void Start () 
	{
		for (int i = 0; i < transform.childCount; i++)
			if (transform.GetChild (i).tag == "EnemyAnimator")
				anim = transform.GetChild (i).GetComponent <Animator> ();

		player = GameObject.FindGameObjectWithTag (("Player")).transform;
		rigidBody = GetComponent <Rigidbody> ();

		int random = Random.Range (0, 4);

		switch(random)
		{
		case 0:
			anim.SetTrigger ("Idle_Neutral");
			break;
		case 1:
			anim.SetTrigger ("Idle_PissedOff");
			break;
		case 2:
			anim.SetTrigger ("Idle_Threat");
			break;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(GameManager.Instance.gameState == GameState.Playing && GameManager.Instance.viewState == ViewState.Top)
		{
			if (chasingPlayer && !isDelayed)
				MoveTowardsPlayer ();			
		}
	}

	void MoveTowardsPlayer ()
	{
		if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
			anim.SetTrigger ("Walk");

		Vector3 target = player.position;
		target.y = transform.position.y;

		transform.LookAt (target);

		rigidBody.MovePosition (transform.position + transform.forward * speed * Time.fixedDeltaTime);
	}

	void Attack ()
	{
		anim.SetTrigger ("Attack");

		Vector3 direction = player.transform.position - transform.position;
		direction.Normalize ();

		player.GetComponent <Rigidbody> ().AddForce (direction * punchForce, ForceMode.Impulse);
	}

	void OnCollisionEnter (Collision collision)
	{
		if(collision.gameObject.tag == "Player" && GameManager.Instance.gameState == GameState.Playing && GameManager.Instance.viewState == ViewState.Top)
		{
			Attack ();
			StartCoroutine (PunchDelay ());
		}
	}

	IEnumerator PunchDelay ()
	{
		isDelayed = true;

		int random = Random.Range (0, 4);

		switch(random)
		{
		case 0:
			anim.SetTrigger ("Idle_Neutral");
			break;
		case 1:
			anim.SetTrigger ("Idle_PissedOff");
			break;
		case 2:
			anim.SetTrigger ("Idle_Threat");
			break;
		}

		yield return new WaitForSeconds ((delayAfterPunch));

		isDelayed = false;
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.tag == "Player")
		{
			chasingPlayer = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if(other.tag == "Player")
		{
			chasingPlayer = false;
		}
	}
}

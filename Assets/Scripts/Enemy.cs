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

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag (("Player")).transform;
		rigidBody = GetComponent <Rigidbody> ();
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
		Vector3 target = player.position;
		target.y = transform.position.y;

		transform.LookAt (target);

		rigidBody.MovePosition (transform.position + transform.forward * speed * Time.fixedDeltaTime);
	}

	void Attack ()
	{
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

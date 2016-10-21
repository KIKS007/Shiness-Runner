using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour 
{
	void OnCollisionEnter (Collision other)
	{
		Debug.Log (other.collider);

		if(other.gameObject.tag == "Player" && GameManager.Instance.gameState == GameState.Playing)
		{
			Debug.Log ("Bite");
			GameManager.Instance.gameState = GameState.GameOver;
			GameManager.Instance.Death();
		}
	}
}

using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour 
{
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "Player" && GameManager.Instance.gameState == GameState.Playing)
		{
			GameManager.Instance.gameState = GameState.GameOver;
			StartCoroutine (Wait ());
		}
	}

	IEnumerator Wait ()
	{
		yield return new WaitForSeconds (0.1f);

		GameManager.Instance.Death();
	}

}

using UnityEngine;
using System.Collections;

public class TransitionTrigger : MonoBehaviour 
{
	public float delayBeforeSpawnProjectiles = 2;

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "Player" && GameManager.Instance.gameState == GameState.Playing)
		{
			if (GameManager.Instance.viewState == ViewState.Top)
			{
				StartCoroutine (WaitBeforeProjectiles ());
				GameManager.Instance.ToSide ();
			}

			else
			{
				ProjectilesSpawnManager.Instance.StopProjectileRandom ();
			}
		}
	}

	void OnTriggerExit (Collider other)
	{
		if(other.gameObject.tag == "Player" && GameManager.Instance.gameState == GameState.Playing)
		{
			if (GameManager.Instance.viewState == ViewState.Side)
			{
				GameManager.Instance.ToTop ();
			}
		}
	}

	IEnumerator WaitBeforeProjectiles ()
	{
		yield return new WaitForSeconds (delayBeforeSpawnProjectiles);

		ProjectilesSpawnManager.Instance.StartProjectileRandom ();
	}
}

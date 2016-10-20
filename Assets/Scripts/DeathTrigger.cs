using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour 
{
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			GameManager.Instance.Death();
		}
	}
}

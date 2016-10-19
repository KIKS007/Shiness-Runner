using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	private static int nbCollision = 0;

	void OnTriggerEnter(Collider other)
	{
		switch (other.tag) {
		case "Poui":
			Destroy (gameObject);
			nbCollision++;
			Debug.Log ("Collision avec Poui, nombre collision : " + nbCollision);
			break;
		case "Player":
			Destroy (gameObject);
			nbCollision++;
			Debug.Log ("Collision avec Player, nombre collision : " + nbCollision);
			break;
		}
	}
}

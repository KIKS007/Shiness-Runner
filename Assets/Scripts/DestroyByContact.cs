using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		switch (other.tag) {
		case "Poui":
			Destroy (gameObject);
			break;
		case "Player":
			Destroy (gameObject);
			break;
		}
	}
}

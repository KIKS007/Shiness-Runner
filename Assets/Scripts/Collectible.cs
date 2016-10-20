using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour
{
	public int score = 0;
	public static int staticScore = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.tag == "Player" || other.tag == "Poui")
		{
			GameManager.Instance.AddToScore (score);
			Debug.Log ("+1 -> Score : " + GameManager.Instance.score);
			Destroy ();
		}
	}

	void Destroy ()
	{
		Destroy (gameObject);
		
	}
}

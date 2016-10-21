using UnityEngine;
using System.Collections;

public enum CollectibleType {Simple, Precious};

public class Collectible : MonoBehaviour
{
	public CollectibleType collectibleType = CollectibleType.Simple;

	public static int normalScore = 1;
	public static int preciousScore = 20;

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
			int score = 0;

			if (collectibleType == CollectibleType.Simple)
				score = normalScore;
			else
				score = preciousScore;

			GameManager.Instance.AddToScore (collectibleType, score);

			if (collectibleType == CollectibleType.Simple)
				Debug.Log ("+" + normalScore.ToString () +  " -> Score : " + GameManager.Instance.score);
			else
				Debug.Log ("+" + preciousScore.ToString () +  " -> Score : " + GameManager.Instance.score);

			Destroy ();
		}
	}

	void Destroy ()
	{
		Destroy (gameObject);
		
	}
}

using UnityEngine;
using System.Collections;

public class DontDestroyOnLoad : MonoBehaviour 
{
	public static DontDestroyOnLoad instance;

	// Use this for initialization
	void Start ()
	{
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);

		DontDestroyOnLoad (this);
	}
}

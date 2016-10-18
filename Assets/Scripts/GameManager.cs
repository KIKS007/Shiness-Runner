using UnityEngine;
using System.Collections;

public enum ViewState {Profile, Top};

public class GameManager :  Singleton<GameManager> 
{
	public ViewState viewState = ViewState.Profile;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}

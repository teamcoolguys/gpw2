using UnityEngine;
using System.Collections;

public class TestMap : MonoBehaviour 
{
	//publics
	public Space[] mGroundFloor;
	public Player mPlayer;

	//privates

	// Use this for initialization
	void Start () 
	{
		mPlayer = gameObject.GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}

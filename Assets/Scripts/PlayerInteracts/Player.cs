//Created by Dylan Fraser
//November 3, 2014
//Jack Ng
//November 4, 2014
//

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TileMap))]
[RequireComponent(typeof(TileMapMouse))]
public class Player : MonoBehaviour
{
	TileMap mTileMap;
	TileMapMouse mMouse;
	GameObject mTileMapObject;
	//privates
	private int mMouseX;
	private int mMouseY;
	private Hand Hand;
	private Space currentSpace;
	private TestMap mCurrentGrid;
	//private TestMap map;
	 
			//Jack//
	public int mCurrentSpot;
	public baseCharacter mCharacter;
	//Tracking current Spot//

	//publics
	public Deck mDeck;

	public GameObject Self;

	public int mInfamy = 0;
	public int mRange = 0;

	// Use this for initialization
	void Start ()
	{
		mTileMapObject=GameObject.Find("CurrentTileMap");
		mMouse = mTileMapObject.GetComponent<TileMapMouse> ();
		mTileMap = mTileMapObject.GetComponent<TileMap>();
		mMouseX = mMouse.mMouseHitX;
		//fixed for negatvie Z values
		mMouseY = -1*mMouse.mMouseHitY-1;
		//fixed for negative Z values
	}

	void Update()
	{
		mMouse = mTileMapObject.GetComponent<TileMapMouse> ();
		mTileMap = mTileMapObject.GetComponent<TileMap>();
		//Debug.Log ("Tile: " + mMouse.mMouseHitX + ", " + mMouse.mMouseHitY);
		mMouseX = mMouse.mMouseHitX;

		//fixed for negatvie Z values
		mMouseY = -1*mMouse.mMouseHitY-1;
		//fixed for negatvie Z values

		if (Input.GetKey ("escape")) 
		{
			Application.Quit ();
		}

		if (Input.GetMouseButtonDown (0)) 
		{
			Debug.Log ("Tile: " + mMouse.mMouseHitX + ", " + mMouse.mMouseHitY);
			Debug.Log ("Tile: " + mMouseX + ", " + mMouseY);
			Debug.Log (mTileMap.MapInfo.GetTileAt(mMouseX,mMouseY));
			if(mTileMap.MapInfo.GetTileAt(mMouseX,mMouseY)==1)
			{
				Debug.Log ("Does it hit");
				Move(mMouse.mMousePosition);
			}
		}
	}
	void Move(Vector3 pos)
	{
		gameObject.transform.position = pos + new Vector3(0.0f, 1.0f, 0.0f);
	}

	public void SetCurrentSpace(Space nextSpace)
	{
		currentSpace = nextSpace;
	}

	public Transform FindCurrentSpace()
	{
		return currentSpace.transform;
	}
}

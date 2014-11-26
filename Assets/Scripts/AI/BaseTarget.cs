using UnityEngine;
using System.Collections;

public class BaseTarget : MonoBehaviour {

	public int mDefense;
	public int mCurDefense;
	
	public int mMovement;
	public int mRunMovement;
	
	public int mInfarmy;
	public int mGold;
	
	public int mDetectionRun;
	public int mDetectionWalk;
	public int mDetectionSee;


	TileMap mTileMap;
	TileMapMouse mMouse;
	GameObject mTileMapObject;
	//privates
	private int mMouseX;
	private int mMouseY;
	// Use this for initialization
	void Start () 
	{
		mTileMapObject=GameObject.Find("CurrentTileMap");
		mMouse = mTileMapObject.GetComponent<TileMapMouse> ();
		mTileMap = mTileMapObject.GetComponent<TileMap>();
		mMouseX = mMouse.mMouseHitX;
		//fixed for negatvie Z values
		mMouseY = -1*mMouse.mMouseHitY-1;
		//Hard fixed for negative Z values
	}
	
	// Update is called once per frame
	void Update () 
	{
		mMouse = mTileMapObject.GetComponent<TileMapMouse> ();
		mTileMap = mTileMapObject.GetComponent<TileMap>();
		//Debug.Log ("Tile: " + mMouse.mMouseHitX + ", " + mMouse.mMouseHitY);
		mMouseX = mMouse.mMouseHitX;
		
		//fixed for negatvie Z values
		mMouseY = -1*mMouse.mMouseHitY-1;
		//fixed for negatvie Z values
		if (Input.GetMouseButtonDown (1)) 
		{
			int temp=mTileMap.MapInfo.GetTileAt(mMouseX,mMouseY);
			Random.Range(0,mMovement);
			Debug.Log (temp);
			switch(temp)
			{
			case 0:
				Debug.Log ("Floor");
				Move(mMouse.mMousePosition);
				break;
			case 1:
				Debug.Log ("Wall");
				break;
			default:
				Debug.Log ("Fuck Off");
				break;
			}

		}
	}
	void Move(Vector3 pos)
	{
		gameObject.transform.position = pos + new Vector3(0.0f, 1.0f, 0.0f);
	}

}

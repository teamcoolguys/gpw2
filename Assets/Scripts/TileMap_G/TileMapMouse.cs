using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TileMap))]
public class TileMapMouse : MonoBehaviour {

	private int mMouseHitX;
	private int mMouseHitY;
	private Vector3 mMousePosition;

	static TileMap _tileMap;
	
	Vector3 currentTileCoord;
	//public GameObject mCube;
	public Transform selectionCube;
	
	void Start() 
	{
		_tileMap = GetComponent<TileMap>();
	}

	// Update is called once per frame
	void Update ()
	{
		Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
		RaycastHit hitInfo;
		if( collider.Raycast( ray, out hitInfo, Mathf.Infinity ) )
		{	
			selectionCube.renderer.enabled = true;
			int x = Mathf.FloorToInt( hitInfo.point.x / _tileMap.tileSize);
			int z = Mathf.FloorToInt( hitInfo.point.z / _tileMap.tileSize);
			Debug.Log ("Tile: " + x + ", " + z);
			
			currentTileCoord.x = x;
			currentTileCoord.z = z;
			mMouseHitX=x;
			mMouseHitY=z;
			mMousePosition=currentTileCoord*_tileMap.tileSize+ new Vector3(0.5f,0.0f,0.5f);
			selectionCube.transform.position = mMousePosition;
		}
		else
		{
			selectionCube.renderer.enabled = false;
			// Hide selection cube?
		}

		if(Input.GetMouseButtonDown(0))
		{
			Debug.Log ("Click!");
		}
	}
}

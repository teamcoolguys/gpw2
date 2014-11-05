//Created by Dylan Fraser
//November 3, 2014
//Jack Ng
//November 4, 2014
//

using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	//privates
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
		//map = GetComponent<TestMap>("FullMap");
	}

	void Update()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			Space Select = gameObject.GetComponent<Space>();

			if(Physics.Raycast (ray, out hit))
			{
				//
				Debug.Log (hit.collider.name);
				//
				mCurrentGrid=GetComponent<TestMap>();

				mCurrentSpot=int.Parse(hit.collider.name);
				//currentSpace=mCurrentGrid.mGroundFloor[mCurrentSpot];
				//if (currentSpace.mSetSpace==Space.OccupyType.Wall)
				//{
				//
				//}
				//else
				{
					Vector3 Picked = hit.collider.transform.position;
					Move(Picked);
				}				//if(gameObject.collider == Space)

				// Move(Picked)
				//
				//Debug.Log (Picked);
				//
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

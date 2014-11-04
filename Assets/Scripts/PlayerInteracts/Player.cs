//Dylan Fraser
//November 3, 2014

using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	//privates
	private Hand Hand;
	private Space currentSpace;
	//private TestMap map;

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

				Vector3 Picked = hit.collider.transform.position;
				Move(Picked);

				//if(gameObject.collider == Space)
				{

				}

				// Move(Picked)
				//
				Debug.Log (Picked);
				//
			}
		}
	}
	void Move(Vector3 pos)
	{
		gameObject.transform.position = pos + new Vector3(0.0f, 2.0f, 0.0f);
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

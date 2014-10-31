using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	//privates
	private Hand Hand;
	private Space currentSpace;

	//publics
	public Deck mDeck;

	public GameObject Self;

	public int mInfamy = 0;
	public int mRange = 0;

	// Use this for initialization
	void Start ()
	{
		TestMap map = GetComponent<TestMap>();


	}

	void Update()
	{
		if (Input.GetMouseButton (0)) 
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			Space Select = gameObject.GetComponent<Space>();

			if(Physics.Raycast (ray, out hit))
			{
				Debug.Log (hit.collider.name);
				int Picked = int.Parse (hit.collider.name);
			}
			
		}
	}

	public void SetCurrentSpace(Space nextSpace)
	{
		currentSpace = nextSpace;
	}

	public Transform FindCurrentSpace()
	{
		return currentSpace.transform/*.position*/;	
	}
}

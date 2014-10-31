using UnityEngine;
using System.Collections;

public class Space : MonoBehaviour 
{
	//publics
	private int mID;
	public OccupyType mSetSpace;

	//privates
	private bool mFull = false;
	private bool mShop = false;
	private GameObject mOccupant;
	private OccupyType mSpaceFilledWith;

	public enum OccupyType
	{
		Empty,
		Player,
		Target,
		NPC,
		Shop,
		Ladder
	};

	void Start()
	{
		mID = int.Parse (this.name);
		mSpaceFilledWith = mSetSpace;

		//use if to instantiate specific space types
	}

	void Update () 
	{

	}

	public void SetOccupant(int Occupy)
	{
		if (mSpaceFilledWith == OccupyType.Empty) 
		{
			mSpaceFilledWith = (OccupyType)Occupy;

		}
	}
	
	public void MoveToSpace() //indicates a unit has moved onto the space
	{
		mFull = true;
	}

	public void LeaveSpace() //indicates a unit has moved off of a space
	{
		mFull = false;
	}

	public bool IsFull() //checks if space is currently filled
	{
		if (mFull == true) 
		{
			return true;
		} 
		else 
		{
			return false;
		}
	}

	public bool IsShop() // checks if space is a shop
	{
		if (mShop == true) 
		{
			return true;
		} 
		else 
		{
			return false;
		}
	}	
}

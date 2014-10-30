using UnityEngine;
using System.Collections;

public class Space : MonoBehaviour 
{
	//publics
	public int mID;

	//privates
	private bool mFull = false;
	public bool mShop = false;
	
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

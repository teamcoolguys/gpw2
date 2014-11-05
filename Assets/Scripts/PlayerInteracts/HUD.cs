using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HUD : MonoBehaviour 
{
	public List<GameObject> deck = new List<GameObject>();

	private List<GameObject> cards = new List<GameObject>();
	private List<GameObject> hand = new List<GameObject>();
	private int cardsDealt = 0;
	private bool showR = false;


	void ResetDeck()
	{
		cardsDealt = 0;
		for (int i = 0; i < hand.Count; i++) 
		{
			Destroy(hand[i]);	
		}
		hand.Clear ();
		cards.Clear ();
		cards.AddRange (deck);
		showR = false;
	}

	GameObject DealCard()
	{
		if (cards.Count == 0) 
		{
			showR = true;
			return null;
			// alternately reset deck with ResetDeck();
		}
		int card = Random.Range (0, cards.Count - 1);
		GameObject go = GameObject.Instantiate (cards [card]) as GameObject;
		cards.RemoveAt (card);

		if (cards.Count == 17) 
		{
			showR = true;
		}
		return go;
	}
	// Use this for initialization
	void Start () 
	{
		ResetDeck ();
	}

	void Gameover()
	{
		cardsDealt = 0;
		for (int v = 0; v < hand.Count; v++) 
		{
			Destroy(hand[v]);	
		}
		hand.Clear ();
		cards.Clear ();
		cards.AddRange (deck);
	}

	void OnGUI()
	{
		if (!showR) 
		{
			if (GUI.Button(new Rect(10,10,100, 20), "Deal"))
			{
				MoveDealtCard();
			}
		}
		else
		{
			if (GUI.Button(new Rect(10, 10, 100, 20), "Reset"))
			{
				ResetDeck();
			}
		}
		if (GUI.Button(new Rect(Screen.width - 110, 10, 100, 20), "GameOver"))
		{
			Gameover();
		}
	}

	void MoveDealtCard()
	{
		GameObject newCard = DealCard ();

		if (newCard == null)
		{
			Debug.Log("Out of Cards");
			showR = true;
			return;
		}
		int offset = 0;
		for (int i= 0; i < cardsDealt; i++) 
		{
			offset = offset + 2;
		}
		GameObject hudd = GameObject.FindGameObjectWithTag("HUD");
		newCard.transform.position = hudd.transform.position;
		newCard.transform.rotation = hudd.transform.rotation;
		newCard.transform.position = new Vector3(newCard.transform.position.x - offset, newCard.transform.position.y, newCard.transform.position.z + offset);
		hand.Add (newCard);
		cardsDealt++;
	}
}

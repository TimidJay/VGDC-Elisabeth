﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class inventoryItems : MonoBehaviour {
    private string Item;
    private GameObject girl;
    
	// Begins the script with Items as "Empty by default"
	void Start ()
    {
        Item = "Empty";
        girl = GameObject.FindGameObjectWithTag("Player");
	}
	
	// returns the item type
	public string getItem ()
    {
        return Item;
	}
    // sets the item type
    public void setItem (string itemName)
    {
        Item = itemName;
        this.gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text = itemName;
    }
    private void OnMouseDown()
    {
        girl.GetComponent<puzzleControl>().setInvItem(Item);
    }
}

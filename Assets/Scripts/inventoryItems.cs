using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class inventoryItems : MonoBehaviour {
    private string Item;
    
    
	// Begins the script with Items as "Empty by default"
	void Start ()
    {
        Item = "Empty";

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
    }
}

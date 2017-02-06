using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puzzleControl : MonoBehaviour
{
    private int puzzlePhase, currentPuzzle;
    private string selectedInvItem, thingClicked;
    
    private string[] inventory;

    //I'm hoping that we can just use this one script on the girl to control all "states" of a room based on where in the puzzle the girl is

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        currentPuzzle = 1;
        puzzlePhase = 1;
        //Set to inventory item when you click on that inv slot
        selectedInvItem = "Empty";
        
        inventory = new string[5];
        for (int i = 0; i < inventory.Length; i++)
        {
            inventory[i] = "Empty";
        }
    }

    // Update is called once per frame
    void Update()
    {
        string[] invUI= new string[5];
        for (int i = 0; i < 5; i++)
        {
            invUI[i] = GameObject.Find("IB"+(i+1).ToString()).GetComponent<inventoryItems>().getItem();
        }
        if (inventory != invUI)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject.Find("IB" + (i + 1).ToString()).GetComponent<inventoryItems>().setItem(inventory[i]);
            }
        }

    }
    //Gets and sets
    public void setThingClicked(string clicked){thingClicked = clicked;}

    //Selects the currently selected inventory item
    public void setInvItem(string item){selectedInvItem = item;}

    public void nextPuzzle(){currentPuzzle += 1;}
    public void nextPhase(){puzzlePhase += 1;}


    public int getPuzzle(){return currentPuzzle;}
    public int getPhase(){return puzzlePhase;}
    public string getInvItem(){return selectedInvItem;}
    public string[] getInv() { return inventory; }
    public bool hasDoll() {
        //if(player.GetComponent<puzzleControl>().getPuzzle()>1||(player.GetComponent<puzzleControl>().getPuzzle()==1&&player.GetComponent<puzzleControl>().getPhase()==6))
        return true;
    }

    public void addToInv(string s)
    {
        //Adds an item to the inventory if there isn't already an instance of that item in the inventory
        //Assuming we set up a fetch quest where items can be picked up in any order, we'd have to make it so we can't submit the items until
        //we reach the right puzzlePhase (where each item pickup increases puzzlePhase by 1, hopefully)
        
            int empty = -1;
            bool alreadyThere = false;
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == "Empty")
                {
                    empty = i;
                    break;
                }
                if (inventory[i] == s)
                {
                    alreadyThere = true;
                    break;
                }
            }
            if (!alreadyThere && empty > -1)
            {
                inventory[empty] = s;
                GameObject.Find("IB" + (empty + 1).ToString()).GetComponent<inventoryItems>().setItem(s);
            }
    }

    public void removeFromInv(string s)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == s)
            {
                inventory[i] = "Empty";
                GameObject.Find("IB"+(i+1).ToString()).GetComponent<inventoryItems>().setItem("Empty");
                break;
            }
        }
    }

    public bool itemCheck(string neededItem)
    {
        if (selectedInvItem == neededItem)
            return true;
        return false;
    }
    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puzzleControl : MonoBehaviour
{
    private int puzzlePhase, currentPuzzle;
    private string selectedInvItem, thingClicked, room;
    
    private string[] inventory;

    //I'm hoping that we can just use this one script on the girl to control all "states" of a room based on where in the puzzle the girl is

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        room = "Room1Perfect";
        currentPuzzle = 1;
        puzzlePhase = 1;
        //Set to inventory item when you click on that inv slot
        selectedInvItem = "empty";
        
        inventory = new string[5];
        for (int i = 0; i < inventory.Length; i++)
        {
            inventory[i] = "empty";
        }
    }

    // Update is called once per frame
    void Update()
    {
        room = SceneManager.GetActiveScene().name;
        if (room == "Room1Perfect"&&currentPuzzle==1)
        {
            //12 phases total - refer to sheet
            //This portion for puzzle solution actions
            if (puzzlePhase == 1)
            {
                //Starting phase of room
            }
            //This portion for flavor text and interactions that are the same for multiple phases
        }
        else if (room == "Room1Perfect")
        {
            //same as puzzlePhase==12 and any flavor texts that function at that time
        }
        print(room);

    }
    //Gets and sets
    void setThingClicked(string clicked){thingClicked = clicked;}
    void setInvItem(string item){selectedInvItem = item;}

    void nextPuzzle(){currentPuzzle += 1;}
    void nextPhase(){puzzlePhase += 1;}


    public int getPuzzle(){return currentPuzzle;}
    public int getPhase(){return puzzlePhase;}
    public string getInvItem(){return selectedInvItem;}
    public string[] getInv() { return inventory; }
    

    public void addToInv(string s)
    {
        //Adds an item to the inventory if there isn't already an instance of that item in the inventory
        //Assuming we set up a fetch quest where items can be picked up in any order, we'd have to make it so we can't submit the items until
        //we reach the right puzzlePhase (where each item pickup increases puzzlePhase by 1, hopefully)
        
            int empty = -1;
            bool alreadyThere = false;
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == "empty")
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
            }
    }

    public void removeFromInv(string s)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == s)
            {
                inventory[i] = "empty";
                break;
            }
        }
        print("Item not found");
    }

    public bool itemCheck(string neededItem)
    {
        if (selectedInvItem == neededItem)
            return true;
        return false;
    }
    

}

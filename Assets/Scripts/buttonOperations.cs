using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonOperations : MonoBehaviour {

    public int puzzle, phaseNeeded;
    public string beforeMessage, solvingMessage, afterMessage,item,neededItem;
    private GameObject girl,textBox;

	// Use this for initialization
	void Start () {
        girl = GameObject.FindGameObjectWithTag("Player");
        textBox = GameObject.FindGameObjectWithTag("Textbox");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        if (phaseNeeded == girl.GetComponent<puzzleControl>().getPhase() && puzzle == girl.GetComponent<puzzleControl>().getPuzzle() && neededItem == girl.GetComponent<puzzleControl>().getInvItem())
        {
            girl.GetComponent<puzzleControl>().nextPhase();
            if (neededItem != "Empty")
            {
                girl.GetComponent<puzzleControl>().removeFromInv(neededItem);
            }
            girl.GetComponent<puzzleControl>().setInvItem("Empty");
            if (item != "Empty")
            {
                girl.GetComponent<puzzleControl>().addToInv(item);
            }
            textBox.GetComponent<textControl>().setText(solvingMessage);
        }
        else if ((phaseNeeded >= girl.GetComponent<puzzleControl>().getPhase() && puzzle == girl.GetComponent<puzzleControl>().getPuzzle()) || puzzle > girl.GetComponent<puzzleControl>().getPuzzle())
        {
            textBox.GetComponent<textControl>().setText(beforeMessage);
        }
        else if ((phaseNeeded < girl.GetComponent<puzzleControl>().getPhase() && puzzle == girl.GetComponent<puzzleControl>().getPuzzle()) || puzzle < girl.GetComponent<puzzleControl>().getPuzzle())
        {
            textBox.GetComponent<textControl>().setText(afterMessage);
        }
    }
}

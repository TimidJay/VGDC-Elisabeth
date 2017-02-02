using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonOperations : MonoBehaviour {

    public int puzzle, phaseNeeded;
    public string beforeMessage, solvingMessage, afterMessage,item;
    private GameObject girl;

	// Use this for initialization
	void Start () {
        girl = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        print("true");
        if (phaseNeeded == girl.GetComponent<puzzleControl>().getPhase() && puzzle == girl.GetComponent<puzzleControl>().getPuzzle())
        {
            if (item != "empty")
            {
                girl.GetComponent<puzzleControl>().addToInv(item);
            }
            girl.GetComponent<puzzleControl>().nextPhase();
            print(solvingMessage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonOperations : MonoBehaviour {

    public int puzzle, phaseNeeded;
    public string beforeMessage, solvingMessage, afterMessage,item,neededItem;
    public bool lastPhase;
    private bool isMoveTarget;
    private GameObject girl,textBox;
    private Animator animator;
	// Use this for initialization
	void Start () {
        girl = GameObject.FindGameObjectWithTag("Player");
        textBox = GameObject.FindGameObjectWithTag("Textbox");
        isMoveTarget = false;
        animator = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isMoveTarget)
        {
            girl.GetComponent<PlayerCtrl>().Move();
            if (girl.transform.position == girl.GetComponent<PlayerCtrl>().getPosition())
            {
                isMoveTarget = false;
                girl.GetComponent<PlayerCtrl>().Stop();
            }
        }
    }

    void OnMouseDown()
    {
        if (!girl.GetComponent<PlayerCtrl>().moving())
        {
            isMoveTarget = true;
            girl.GetComponent<PlayerCtrl>().setTargetPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (phaseNeeded == girl.GetComponent<puzzleControl>().getPhase() && puzzle == girl.GetComponent<puzzleControl>().getPuzzle() && neededItem == girl.GetComponent<puzzleControl>().getInvItem())
            {
                if (!lastPhase)
                {
                    girl.GetComponent<puzzleControl>().nextPhase();
                }
                else
                {
                    girl.GetComponent<puzzleControl>().nextPuzzle();
                }
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
}

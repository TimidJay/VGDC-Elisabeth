using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonOperations : MonoBehaviour {

    public int puzzle, phaseNeeded,listPosition=0;
    public string beforeMessage, solvingMessage, afterMessage,item,neededItem;
    public string[] messageList;
    public bool lastPhase,increasesPhase,disappears;
    private bool isMoveTarget;
    private GameObject girl,textBox;
 
	// Use this for initialization
	void Start () {
        girl = GameObject.FindGameObjectWithTag("Player");
        textBox = GameObject.FindGameObjectWithTag("Textbox");
        isMoveTarget = false;
        
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
            if (girl.transform.position.x > girl.GetComponent<PlayerCtrl>().getPosition().x)
            {
                girl.GetComponent<PlayerCtrl>().setAnimator(1);
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
                if (increasesPhase)
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
                    if (disappears)
                    {
                        Destroy(this);
                    }
                }
                textBox.GetComponent<textControl>().setText(solvingMessage);
            }
            else if ((phaseNeeded >= girl.GetComponent<puzzleControl>().getPhase() && puzzle == girl.GetComponent<puzzleControl>().getPuzzle()) || puzzle > girl.GetComponent<puzzleControl>().getPuzzle())
            {
                textBox.GetComponent<textControl>().setText(beforeMessage);
            }
            else if ((phaseNeeded < girl.GetComponent<puzzleControl>().getPhase() && puzzle == girl.GetComponent<puzzleControl>().getPuzzle()) || puzzle < girl.GetComponent<puzzleControl>().getPuzzle())
            {
                if (afterMessage != " ")
                {
                    textBox.GetComponent<textControl>().setText(afterMessage);
                }
                else if (afterMessage == "")
                {
                }
                else
                {
                    textBox.GetComponent<textControl>().setText(messageList[listPosition]);
                    if (listPosition == messageList.Length - 1)
                    {
                        listPosition = 0;
                    }
                    else
                        listPosition++;
                }
            }
        }
    }
}

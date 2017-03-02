using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonOperations : MonoBehaviour {

    public int puzzle, phaseNeeded;
    public string beforeMessage, solvingMessage, afterMessage,item,neededItem;
    public string[] messageList;
    public bool lastPhase, increasesPhase, disappears,moveTo=true;
    private bool isMoveTarget, showMessage = false, cutscene = true;
    private GameObject girl,textBox;
    private int listPosition = 0;
    public bool audio;


    // Use this for initialization
    void Start () {
        girl = GameObject.FindGameObjectWithTag("Player");
        textBox = GameObject.FindGameObjectWithTag("Textbox");
        isMoveTarget = false;

        StartCoroutine("Introduction");
    }
	
	// Update is called once per frame
	void Update () {
        if (isMoveTarget && cutscene == false)
        {
            girl.GetComponent<PlayerCtrl>().Move();
            //Code that runs when the girl arrives at target object
            if (girl.transform.position == girl.GetComponent<PlayerCtrl>().getPosition())
            {
                //Sets the girl to standing position
                if (girl.GetComponent<PlayerCtrl>().getInteger() == 0)
                {
                    girl.GetComponent<PlayerCtrl>().setAnimator(3);
                }
                if (girl.GetComponent<PlayerCtrl>().getInteger() == 1)
                {
                    girl.GetComponent<PlayerCtrl>().setAnimator(2);
                }
                girl.GetComponent<PlayerCtrl>().Stop();
                if (showMessage)
                {
                    if (phaseNeeded == girl.GetComponent<puzzleControl>().getPhase() && puzzle == girl.GetComponent<puzzleControl>().getPuzzle() && neededItem == girl.GetComponent<puzzleControl>().getInvItem())
                    {
                        //Performs this if this is the object the girl currently needs to interact with
                        //If the girl needs to use an item on the object to clear the phase, then code treats it as if the girl hasn't cleared the object's phase (i.e. goes to the else if instead of this batch of code)
                        if (increasesPhase)
                        {
                            if (!lastPhase)
                            {
                                //Increments puzzle phase if it isn't the last one
                                girl.GetComponent<puzzleControl>().nextPhase();
                            }
                            else
                            {
                                //Increments the girl's current puzzle if this object is the last one involved in the puzzle (determined by the public lastPhase boolean)
                                girl.GetComponent<puzzleControl>().nextPuzzle();
                            }
                            if (neededItem != "Empty")
                            {
                                //If an item is required to clear the phase, deletes it from the inventory (assumes no items will be used multiple times)
                                girl.GetComponent<puzzleControl>().removeFromInv(neededItem);
                            }
                            girl.GetComponent<puzzleControl>().setInvItem("Empty");
                            if (item != "Empty")
                            {
                                //Adds the object's item to inveontory, if the object has one
                                girl.GetComponent<puzzleControl>().addToInv(item);
                            }
                            if (disappears)
                            {
                                //Deletes the object if it's supposed to disappear
                                //Not sure if this is necessary, but keeping it just in case
                                Destroy(this);
                            }
                        }
                        textBox.GetComponent<textControl>().setText(solvingMessage);
                    }
                    else if ((phaseNeeded >= girl.GetComponent<puzzleControl>().getPhase() && puzzle == girl.GetComponent<puzzleControl>().getPuzzle()) || puzzle > girl.GetComponent<puzzleControl>().getPuzzle())
                    {
                        //If the girl hasn't cleared this object's needed phase, this message displays
                        if (audio)
                        {
                            AudioSource audio = GetComponent<AudioSource>();

                            audio.Play();
                        }
                       
                        textBox.GetComponent<textControl>().setText(beforeMessage);
                        


                    }
                    else if ((phaseNeeded < girl.GetComponent<puzzleControl>().getPhase() && puzzle == girl.GetComponent<puzzleControl>().getPuzzle()) || puzzle < girl.GetComponent<puzzleControl>().getPuzzle())
                    {
                        //checks to see if the girl's already cleared the needed phase for this object
                        if (afterMessage != " ")
                        {
                            //Presents the normal text message
                            textBox.GetComponent<textControl>().setText(afterMessage);
                        }
                        else if (afterMessage == "")
                        {
                            //assumes there is no message given when leaving a room. This will probably be for doors
                        }
                        else
                        {
                            //This is for when there's a list of messages to send.
                            textBox.GetComponent<textControl>().setText(messageList[listPosition]);
                            if (listPosition == messageList.Length - 1)
                            {
                                listPosition = 0;
                            }
                            else
                                listPosition++;
                        }
                    }
                    //Toggles to avoid locking the textBox onto one message
                    showMessage = false;
                }
            }
            //Animates the girl's movement
            else if (girl.transform.position.x > girl.GetComponent<PlayerCtrl>().getPosition().x)
            {
                girl.GetComponent<PlayerCtrl>().setAnimator(1);

            }
            else if (girl.transform.position.x < girl.GetComponent<PlayerCtrl>().getPosition().x)
            {
                girl.GetComponent<PlayerCtrl>().setAnimator(0);

            }

        }
    }

    IEnumerator Introduction()
    {
        //Intro text sequence
        if (cutscene)
        {
            textBox.GetComponent<textControl>().setText("Mommy and Daddy don't let me go outside");
            yield return new WaitForSeconds(2f);
            textBox.GetComponent<textControl>().setText("I can only play when strangers visit");
            yield return new WaitForSeconds(2f);
            textBox.GetComponent<textControl>().setText("No one's visiting, but I want to go play!");
            yield return new WaitForSeconds(2f);
            textBox.GetComponent<textControl>().setText("(Click on things to interact!)");
        }
        cutscene = false;
    }

    void OnMouseDown()
    {
        //Toggles booleans to make the girl move, to show the textbox's message
        //The first conditional checks if the object is one the girl is supposed to move to - will only be false in zoom-ins like that lock
        if(cutscene == false)
        {
            if (moveTo)
            {
                if (!girl.GetComponent<PlayerCtrl>().moving())
                {
                    isMoveTarget = true;
                    girl.GetComponent<PlayerCtrl>().setTargetPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }
            }
            //showMessage is important in order to prevent text messages from being spammed every update
            //Without it, the textbox will only display the first message it ever receives. This also prevents a list of messages from changing messages every update.
            showMessage = true;
        }
    }
}

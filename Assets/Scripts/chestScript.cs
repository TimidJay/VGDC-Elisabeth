using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chestScript : MonoBehaviour {
    private int[] lockDisplay;
    private bool unlocked = false;


    // Use this for initialization
    void Start()
    {
        lockDisplay = [0, 0, 0, 0];



    }

    public void decreaseLockNum(int: lockPlace)
    {
        if (lockDisplay[lockPlace] != 9)
        {
            lockDisplay[lockPlace] = lockDisplay[lockPlace] + 1;
        }
        else
        {
            lockDisplay[lockPLace] = 0;
        }
        
    }
	public void increaseLockNum(int: lockPlace)
    {
		if(lockDisplay[lockPlace] != 0)
        {
            lockDisplay[lockPlace] = lockDisplay[lockPlace] - 1;

        }
        else
        {
            lockDisplay[lockPlace] = 9;
        }
	}

    private void checkLock()
    {
        if (lockDisplay[0] == 8 && lockDisplay[1] == 3 && lockDisplay[2] == 5 && lockDisplay[3] == 7)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

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
        lockDisplay = new int[4];
        lockDisplay[0] = 0;
        lockDisplay[1] = 0;
        lockDisplay[2] = 0;
        lockDisplay[3] = 0;





    }

    public void decreaseLockNum(int lockPlace)
    {
        if (lockDisplay[lockPlace] != 9)
        {
            lockDisplay[lockPlace] = lockDisplay[lockPlace] + 1;
        }
        else
        {
            lockDisplay[lockPlace] = 0;
        }
        
    }
	public void increaseLockNum(int lockPlace)
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

    private bool checkLock()
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

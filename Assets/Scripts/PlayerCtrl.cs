using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {
    private Vector3 targetPosition;
    private bool isMoving = false;
    
    // Update is called once per frame
   
    
    public void Move () {

		//if(Input.GetKeyDown(KeyCode.Mouse0))
       // {
            targetPosition.y = -2;  /// -2 is tentative, all depends on what the set bottom floor is
      //  }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 5);
	}
    public void Stop()
    {
        isMoving = false;
    }
    public void setTargetPosition(Vector3 position)
    {
        targetPosition = position;
        targetPosition.z = 0;
        isMoving = true;
    }
    public Vector3 getPosition()
    {
        return targetPosition;
    }
    public bool moving()
    {
        return isMoving;
    }
}

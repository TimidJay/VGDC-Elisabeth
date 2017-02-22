using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {
    private Vector3 targetPosition;
    private bool isMoving = false;
    private Animator animator;
    // Update is called once per frame

    public void Start()
    {
        animator = this.GetComponent<Animator>();
    }
    void Update()
    {
       /// if (isMoving)
     //   {
        //    if (targetPosition.x < transform.position.x)
        //    {
          //      animator.SetInteger("Direction", 1);
           //     if (targetPosition.x == transform.position.x)
           //     {
            //        animator.SetInteger("Direction", 3);
            //    }
          //  }
       // }
    }

    public Animator getAnimator()
    {
        return animator;
    }
    public void setAnimator(int x)
    {
        animator.SetInteger("Direction", x);
    }
	public int getInteger() {
		return animator.GetInteger ("Direction");
	}
    public void Move () {
		targetPosition.y = -3;
		  /// -2 is tentative, all depends on what the set bottom floor is
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * 5 );
       
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

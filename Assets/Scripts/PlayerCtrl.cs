using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {
    public Vector2 targetPosition;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.y = -2;  /// -2 is tentative, all depends on what the set bottom floor is
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 5);
	}
}

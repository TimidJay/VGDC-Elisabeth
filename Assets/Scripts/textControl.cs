using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textControl : MonoBehaviour {
    private string message;
	// Use this for initialization
	void Start () {
        message = "";	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setText(string text)
    {
        message = text;
        this.gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text = message;
    }
}

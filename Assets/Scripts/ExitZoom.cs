using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitZoom : MonoBehaviour {
    public string destination;
    private GameObject menu;
    // Use this for initialization
    private void Start()
    {
        menu = GameObject.FindGameObjectWithTag("MenuCtrl");
    }
    private void OnMouseDown()
    {
        print("true");
        menu.GetComponent<MenuCTRL>().LoadScene(destination);
    }
}

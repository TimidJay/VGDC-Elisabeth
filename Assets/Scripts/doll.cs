﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doll : MonoBehaviour {
    public string dollScene;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnMouseDown()
    {
        if (player.GetComponent<puzzleControl>().hasDoll())
        {
            this.gameObject.GetComponent<MenuCTRL>().LoadScene(dollScene);
        }
    }
}

﻿using UnityEngine;
using System.Collections;
using System.Linq;
using Rewired;
public class UICreditsInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (ReInput.players.AllPlayers.Any(a => a.GetButtonDown("StartA")))
            Application.LoadLevel("menu");
    }
}

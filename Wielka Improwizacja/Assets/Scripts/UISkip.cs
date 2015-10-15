using UnityEngine;
using System.Collections;
using System.Linq;
using Rewired;

public class UISkip : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (ReInput.players.AllPlayers.Any(a => a.GetAnyButtonDown()))
            Application.LoadLevel("menu");
    }
}

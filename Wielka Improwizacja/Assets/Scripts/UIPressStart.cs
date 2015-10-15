using UnityEngine;
using System.Collections;
using Rewired;
using System.Linq;

public class UIPressStart : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ReInput.players.AllPlayers.Any(a => a.GetButtonDown("Start")))
            Application.LoadLevel(Application.loadedLevel + 1);
    }
}

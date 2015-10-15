using UnityEngine;
using System.Linq;

public class UIGameOverInput : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Rewired.ReInput.players.AllPlayers.Any(a => a.GetButtonDown("Start")))
            Application.LoadLevel("Menu");
    }
}

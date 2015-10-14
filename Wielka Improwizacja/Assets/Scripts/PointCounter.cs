using System;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
	public bool usingLeftPanel;
	public int totalPoints { get; private set; }

	void Awake () {
		totalPoints=0;
	}
	public void AddPoint (int points ) {
		totalPoints += points;
		if ( usingLeftPanel ) UIController.Instance.DisplayLeftScore(totalPoints);
		else UIController.Instance.DisplayRightScore(totalPoints);
	}
}


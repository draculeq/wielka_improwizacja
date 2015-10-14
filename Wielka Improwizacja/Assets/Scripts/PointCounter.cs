using System;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
	public bool usingLeftPanel;
	int totalPoints;

	void Awake () {
		totalPoints=0;
	}
	public void AddPoint (int points ) {
		totalPoints += points;
		if ( usingLeftPanel ) UIController.Instance.DisplayLeftScore(totalPoints);
		else UIController.Instance.DisplayRightScore(totalPoints);
	}
}


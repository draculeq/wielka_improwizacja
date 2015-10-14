using System;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
	public bool usingLeftPanel;
	[SerializeField] UIScore ui_score;
	int totalPoints;
	PlayerController contro;

	void Awake () {
		totalPoints=0;
		contro = GetComponent<PlayerController>();
	}
	public void AddPoint (int points ) {
		totalPoints += points;
		if ( usingLeftPanel ) UIController.Instance.DisplayLeftScore(totalPoints);
		else UIController.Instance.DisplayRightScore(totalPoints);
	}
}


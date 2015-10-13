using UnityEngine;
using System.Collections;

public class PointCounter : MonoBehaviour
{
	int p;

	void Awake () {
		p=0;
	}
	public void AddPoint (int points ) {
		p += points;
		Debug.Log(gameObject.name + " gets " + points + " points");
	}
}


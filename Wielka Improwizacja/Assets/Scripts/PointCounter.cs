using System;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
	int p;
    public event Action<int> PointAdded; 
	void Awake () {
		p=0;
	}
	public void AddPoint (int points ) {
		p += points;
		Debug.Log("player get points = " + points + " PointAdded == null? " + (PointAdded == null) );
	    if (PointAdded != null) PointAdded(p);
	}

	public bool NullCheck () {
		return PointAdded == null;
	}
}


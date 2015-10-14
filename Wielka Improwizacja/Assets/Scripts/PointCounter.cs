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
	    if (PointAdded != null) PointAdded(p);
	}
}


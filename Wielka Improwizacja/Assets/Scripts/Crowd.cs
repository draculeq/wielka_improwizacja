using UnityEngine;
using System.Collections;

public class Crowd : MonoBehaviour {
	public CrowdRow[] rows { get; private set; }

	void Awake () {
		rows = GetComponentsInChildren<CrowdRow>();
	}

}

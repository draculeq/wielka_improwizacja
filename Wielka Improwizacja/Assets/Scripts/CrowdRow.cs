using UnityEngine;
using System.Collections;

public class CrowdRow : MonoBehaviour {
	Transform[] list;

	void Start () {
		list = gameObject.GetComponentsInChildren<Transform>();
	}
}

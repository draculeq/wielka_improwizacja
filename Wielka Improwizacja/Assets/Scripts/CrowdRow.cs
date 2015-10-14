using UnityEngine;
using System.Collections;

public class CrowdRow : MonoBehaviour {
	Transform[] list;

	void Start () {
		list = gameObject.GetComponentsInChildren<Transform>();
		Debug.Log("list==null?"+ (list == null));
		if ( list != null ) Debug.Log("list.length="+ list.Length);
	}
}

using UnityEngine;
using System.Collections;

public class CrowdRow : MonoBehaviour {
	Transform[] list;
	
	public float frequency;
	public float amplitude;

	void Start () {
		list = gameObject.GetComponentsInChildren<Transform>();
		tmp = Vector3.zero;
		orgin_y = list[0].position.y;
	}

	Vector3 tmp;
	float orgin_y;

	public void RandomMove () {
		foreach ( var k in list ) {
			var t = k.position;
			t.y = orgin_y +  Mathf.PerlinNoise(t.x,Time.time*frequency) *amplitude;
			k.position = t;
		}
	}

	void Update () {
		RandomMove ();
	}
}

using UnityEngine;
using System.Collections;

public class CrowdRow : MonoBehaviour {
	public Transform[] heads  { get; private set; }
	
	public float frequency;
	public float amplitude;

	void Awake () {
		heads = gameObject.GetComponentsInChildren<Transform>();
		tmp = Vector3.zero;
		orgin_y = heads[0].position.y;
	}

	Vector3 tmp;
	float orgin_y;

	public void RandomMove () {
		foreach ( var k in heads ) {
			var t = k.position;
			t.y = orgin_y +  Mathf.PerlinNoise(t.x,Time.time*frequency) *amplitude;
			k.position = t;
		}
	}

	void Update () {
		RandomMove ();
	}
}

using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	[SerializeField] float range;

	[SerializeField] Vector3 force;
	[SerializeField] float strength;
	[SerializeField] float deltaStrength;
	[SerializeField] ForceMode mode;

	Pool pomidorPool, kwiatekPool;

	Vector3 basePos;
	Vector3 _tmp;

	void Start () {
		pomidorPool = PoolManager.Instance.Get("pomidor");
		//kwiatekPool = PoolManager.Instance.Get("kwiatek");

		basePos = transform.position;
		_tmp = basePos;
	}


	void OnGUI () {
		if ( GUILayout.Button("Spawn") ) {
			var k = pomidorPool.Get();
			_tmp.Set ((Random.value - 0.5f) * range * 2, _tmp.y, _tmp.z);
			k.transform.position = _tmp;
			k.GetComponent<Rigidbody>().AddForce(force* (strength + ((Random.value - 0.5f) * deltaStrength*2 )) ,mode);
		}
	}
}


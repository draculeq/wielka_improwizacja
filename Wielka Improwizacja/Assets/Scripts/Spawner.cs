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
	Vector3 _tmp2;

	void Start () {
		pomidorPool = PoolManager.Instance.Get("pomidor");
		kwiatekPool = PoolManager.Instance.Get("kwiatek");

		basePos = transform.position;
		_tmp = basePos;
		_tmp2 = Vector3.zero;
	}
	
	public void ThrowPomidorAt ( Vector3 player_pos, int nb ) {
		while ( nb > 0 ) {
			var k = pomidorPool.Get();
			_tmp.Set (player_pos.x, _tmp.y, _tmp.z);
			k.transform.position = _tmp;
			_tmp2.Set ( force.x+ Random.value* throwPomidorRandomRangeOffset - throwPomidorRandomRangeOffset/2 , force.y + Random.value* throwPomidorRandomRangeOffset - throwPomidorRandomRangeOffset/2, force.z);
			k.GetComponent<Rigidbody>().AddForce(_tmp2* (strength + Random.value  * deltaStrength)*1.1f ,mode);
			nb --;
		}
	}

	[Range(0,1f)]
	public float throwFlowerRandomRangeOffset;
	[Range(0,4f)]
	public float throwPomidorRandomRangeOffset;

	public void ThrowKwiatekAround (Vector3 player_pos, int nb ) {
		while ( nb > 0 ) {
			var k = kwiatekPool.Get();
			_tmp.Set (player_pos.x, _tmp.y, _tmp.z);
			k.transform.position = _tmp;
			_tmp2.Set ( force.x + Random.Range(0,throwFlowerRandomRangeOffset)-throwFlowerRandomRangeOffset/2, force.y, force.z);
			k.GetComponent<Rigidbody>().AddForce(_tmp2* (strength + ((Random.value - 0.5f) * deltaStrength*2 )) ,mode);
			nb --;
		}
	}

	#region hide
	private static Spawner _instance;
	public static Spawner Instance {
		get {
			if ( _instance == null ) {
				_instance = GameObject.FindObjectOfType(typeof(Spawner)) as Spawner;
			}
			return _instance;
		}
	}
	#endregion
}


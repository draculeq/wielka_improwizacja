using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class PoolableObject : MonoBehaviour
{
	public int point = 1;
	public float lyingTime = 3f;
	bool deactivated;
	public bool IsFree () {
		return deactivated;
	}

	public void Deactivate() {
		gameObject.SetActive(false);
		deactivated = true;
		if ( _t != null ) {
			StopCoroutine(_t);
			_t = null;
		}
	}

	public void Activate () {
		gameObject.SetActive(true);
		deactivated = false;
	}

	IEnumerator _t;
	void OnCollisionEnter(Collision other ) {
		if ( !deactivated & _t != null ) {
			StartCoroutine (_t = WaitOnFloor () );
		}
	}

	IEnumerator WaitOnFloor () {
		yield return new WaitForSeconds(lyingTime);
		if ( !deactivated ) Deactivate();
	}
}


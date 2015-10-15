using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody),typeof(Collider))]
public abstract class IThrowableObject : IPoolableObject
{
	public int point = 1;
	public float lyingTime = 3f;
	
	public bool directContactOnly;
	public bool isOnGround { get; private set; } 

	virtual public void PlayOnTriggerSound () {
	}

	virtual public void Deactivate ()
	{
		base.Deactivate ();
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		
		isOnGround = false;
		if ( _t != null ) {
			StopCoroutine(_t);
			_t = null;
		}
	}

	IEnumerator _t;
	void OnCollisionEnter(Collision other ) {
		if ( !deactivated ) {
			if ( other.gameObject.name.Equals("Floor") ) {
				isOnGround = true;
			}
		}
		if ( !deactivated & _t == null ) {
			StartCoroutine (_t = WaitOnFloor () );
		}
	}
	
	IEnumerator WaitOnFloor () {
		yield return new WaitForSeconds(lyingTime);
		if ( !deactivated ) Deactivate();
	}
}


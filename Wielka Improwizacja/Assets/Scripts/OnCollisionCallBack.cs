using UnityEngine;
using System.Collections;

public class OnCollisionCallBack : MonoBehaviour {
	[SerializeField] PointCounter counter;


	void OnTriggerEnter(Collider other ) {
		Debug.Log("OnCollisionCallBack.OnTriggerEnter");
		var poolableOb = other.gameObject.GetComponent<PoolableObject>();
		if ( poolableOb != null ) {
			Debug.Log("OnCollisionCallBack.OnTriggerEnter2\ndirectContactOnly="+poolableOb.directContactOnly
			          + " isOnGround="+poolableOb.isOnGround);
			if ( poolableOb.directContactOnly & poolableOb.isOnGround ) return;
			Debug.Log("OnCollisionCallBack.OnTriggerEnter3");
			counter.AddPoint(poolableOb.point);
			poolableOb.Deactivate();
		}
	}
}

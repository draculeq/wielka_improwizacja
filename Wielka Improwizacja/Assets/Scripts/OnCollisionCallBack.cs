using UnityEngine;
using System.Collections;

public class OnCollisionCallBack : MonoBehaviour {
	[SerializeField] PointCounter counter;


	void OnTriggerEnter(Collider other ) {
		var poolableOb = other.gameObject.GetComponent<IPoolableObject>();
		if ( poolableOb != null ) {
			if ( poolableOb.directContactOnly & poolableOb.isOnGround ) return;
			if ( counter != null ) counter.AddPoint(poolableOb.point);
			poolableOb.PlayOnTriggerSound();
			poolableOb.Deactivate();
		}
	}
}

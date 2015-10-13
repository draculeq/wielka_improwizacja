using UnityEngine;
using System.Collections;

public class OnCollisionCallBack : MonoBehaviour {
	[SerializeField] PointCounter counter;


	void OnTriggerEnter(Collider other ) {
		var poolableOb = other.gameObject.GetComponent<PoolableObject>();
		if ( poolableOb != null ) {
			counter.AddPoint(poolableOb.point);
			poolableOb.Deactivate();
		}
	}
}

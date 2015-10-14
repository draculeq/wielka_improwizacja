using UnityEngine;
using System.Collections;

public class OnCollisionCallBack : MonoBehaviour {
	[SerializeField] PointCounter counter;


	void OnTriggerEnter(Collider other ) {
		var poolableOb = other.gameObject.GetComponent<PoolableObject>();
		if ( poolableOb != null ) {
			if ( poolableOb.directContactOnly & poolableOb.isOnGround ) return;
			if ( counter != null ) counter.AddPoint(poolableOb.point);
			AudioController.Instance.PomidorCrashed();
			poolableOb.Deactivate();
		}
	}
}

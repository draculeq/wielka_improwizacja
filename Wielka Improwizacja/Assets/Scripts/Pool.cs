using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pool : MonoBehaviour {
	[SerializeField] PoolableObject prefab;
	public int initCap;
	public string name;

	List<PoolableObject> list;

	void Awake () {
		if ( initCap < 0 ) throw new UnityException("initCap < 0 ");
		list = new List<PoolableObject>(initCap);
		for ( int i =0; i < initCap; i ++ ) {
			GameObject g = Instantiate(prefab.gameObject);
			g.transform.SetParent(transform);
			var _p = g.GetComponent<PoolableObject>();
			_p.Deactivate();
			list.Add(_p);
		}
	}

	public GameObject Get () {
		foreach ( var o in list ) {
			if ( o.IsFree() ) {
				o.Activate();
				return o.gameObject;
			}
		}

		GameObject g = Instantiate(prefab.gameObject);
		g.transform.SetParent(transform);
		var _p = g.GetComponent<PoolableObject>();
		_p.Activate();
		list.Add(_p);

		return _p.gameObject;
	}
}

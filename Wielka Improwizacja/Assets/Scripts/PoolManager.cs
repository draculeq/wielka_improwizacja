using UnityEngine;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour
{
	[SerializeField] Pool[] pools;	

	Dictionary<string, Pool> dict; 
	static bool awaked;

	public Pool Get ( string name ) {
		Pool p = null;
		dict.TryGetValue(name, out p );
		if ( p == null ) throw new UnityException("Error - check names of pools");
		return p;
	}

	void Awake () {
		dict = new Dictionary<string, Pool>(pools.Length);
		foreach ( var p in pools ) {
			dict.Add(p.name, p);
		}

		awaked = true;
	}

	#region hide
	private static PoolManager _instance;
	public static PoolManager Instance {
		get {
			if ( _instance == null ) {
				if ( awaked ) 
					_instance = GameObject.FindObjectOfType(typeof(PoolManager)) as PoolManager;
				else throw new UnityException("Class hasnt been initialized yet");
			}
			return _instance;
		}
	}
	#endregion
}


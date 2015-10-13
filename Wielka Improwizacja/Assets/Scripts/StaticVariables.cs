using UnityEngine;
using System.Collections;

public class StaticVariables : MonoBehaviour
{
	#region hide
	private static StaticVariables _instance;
	public static StaticVariables Instance {
		get {
			if ( _instance == null ) {
				_instance = GameObject.FindObjectOfType(typeof(StaticVariables)) as StaticVariables;
			}
			return _instance;
		}
	}
	#endregion
}


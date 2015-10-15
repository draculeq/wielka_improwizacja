using UnityEngine;
using System.Collections;

public abstract class IPoolableObject : MonoBehaviour
{
	protected bool deactivated;

	public bool IsFree () {
		return deactivated;
	}

	virtual public void Deactivate() {
		gameObject.SetActive(false);
		deactivated = true;
	}

	virtual public void Activate () {
		gameObject.SetActive(true);
		deactivated = false;
	}


}


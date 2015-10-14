using UnityEngine;
using System.Collections;

public class Pomidor : IPoolableObject
{
	public override void PlayOnTriggerSound ()
	{
		AudioController.Instance.PomidorCrashed();
	}	
}


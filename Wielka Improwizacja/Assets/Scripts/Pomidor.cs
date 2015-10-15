using UnityEngine;
using System.Collections;

public class Pomidor : IThrowableObject
{
	public override void PlayOnTriggerSound ()
	{
		AudioController.Instance.PomidorCrashed();
	}	
}


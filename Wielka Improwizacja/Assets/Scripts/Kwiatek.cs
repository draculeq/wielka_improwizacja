using UnityEngine;
using System.Collections;

public class Kwiatek : IPoolableObject
{
	public override void PlayOnTriggerSound ()
	{
		AudioController.Instance.KwiatekCaptured();
	}
}

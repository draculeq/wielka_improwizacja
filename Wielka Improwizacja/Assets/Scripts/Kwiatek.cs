using UnityEngine;
using System.Collections;

public class Kwiatek : IThrowableObject
{
	public override void PlayOnTriggerSound ()
	{
		AudioController.Instance.KwiatekCaptured();
	}
}
using UnityEngine;
using System.Collections;

public enum VisualTextDisplayType { LeftCurve, RightCurve, ZikZag }

[RequireComponent(typeof(Animator))]
public class VisualText : IPoolableObject
{

	public float lifeTime = 1; // default life life, if changed need to be sync with real life time of animation clip
	Transform source;
	VisualTextDisplayType type;
	public Animator animator { get; private set; }
	public SpriteRenderer spriteRenderer { get; private set; }
	
	void Awake () { 
		animator = GetComponent<Animator>(); 
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();
	} 

	public void Setup ( Transform _source,VisualTextDisplayType  type ) {
		source = _source;
	}

	public void FloatUpZigZak () {

	}
	bool _run;

	public override void Activate ()
	{
		base.Activate ();
	}

	public override void Deactivate ()
	{
		base.Deactivate ();
		source = null;
		_run = false;
	}

	public void Run () {
		_run = true;
		_timer = lifeTime;
	}

	public void ForceStop () {
		Deactivate();
	}

	float _timer;

	void Update () {
		if ( _run ) {
			_timer -= Time.deltaTime;
			if ( _timer < 0 ) Deactivate();
		}
	}


}


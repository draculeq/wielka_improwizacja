using UnityEngine;
using System.Collections;

public enum DisplayType { FadeOut, DizzyFloatUp } 
public class VisualTextControl : MonoBehaviour
{
	[SerializeField] Sprite buu,combo,mistrz,nieslyn,znakomicie;

	Pool _pool;

	Pool pool { 
		get {
			if ( _pool == null ) 
				_pool = PoolManager.Instance.Get("visual_text");
			return _pool;
		}
		set {
			_pool = pool;
		}
	}

	void Start () {
		animations = new int[] { 
			Animator.StringToHash("vi_text_lightcurve"),
			Animator.StringToHash("vi_text_leftcurve"),
			Animator.StringToHash("vi_text_zikzag"),
			Animator.StringToHash("vi_text_grow")
		};
	}

	int[] animations; 

	public void RandomCombo (int combo_index, Vector3 pos ) {
		if (combo_index == 0) Combo(pos,"combo");
		if (combo_index == 1) Combo(pos,"nieslyn");
		if (combo_index == 2) Combo(pos,"mistrz");
	}
	
	public void Combo (Vector3 pos , string text ) {
		var t = pool.Get();
		t.transform.position = pos;
		var vt = t.GetComponent<VisualText>();
		vt.spriteRenderer.sprite = ApplySprite(text);
		vt.animator.Play(animations[Random.Range(0,animations.Length)]);
		vt.Run();
	}

	public void Boo( Vector3 pos,string text ) {
		pos.y += 1;
		var t = pool.Get();
		t.transform.position = pos;
		var vt = t.GetComponent<VisualText>();
		vt.spriteRenderer.sprite = ApplySprite(text);
		vt.animator.Play(animations[Random.Range(0,animations.Length)]);
		vt.Run();
	}

	public void RandomBoo ( int nb ) {
		var crowd = FindObjectOfType<Crowd>();
		int sum = 0;
		foreach (var r in crowd.rows ){
			sum += r.heads.Length;
		}

		while ( nb > 0 ) {
			int index = Random.Range(0, sum);

			if ( index < crowd.rows[0].heads.Length ) {
				Boo(crowd.rows[0].heads[index].position,"boo");
				nb --;
				continue;
			} 
			index -= crowd.rows[0].heads.Length;

			if ( index < crowd.rows[1].heads.Length ) {
				Boo(crowd.rows[1].heads[index].position,"boo");
				nb --;
				continue;
			} 
			
			index -= crowd.rows[1].heads.Length;

			if ( index < crowd.rows[2].heads.Length ) {
				Boo(crowd.rows[2].heads[index].position,"boo");
				nb --;
				continue;
			} 

			nb --;
		}
	}

	Sprite ApplySprite (string s ) {
		switch (s ) {
		case "boo" :
			return buu;
		case "combo":
			return combo;
		case "mistrz":
			return mistrz;
		case "nieslyn":
			return nieslyn;
		case "znakomicie":
			return znakomicie;
		default :
			throw new UnityException("error in name, s = " + s );
		}
	}

	#region hide
	private static VisualTextControl _instance;
	public static VisualTextControl Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = GameObject.FindObjectOfType(typeof(VisualTextControl)) as VisualTextControl;
			}
			return _instance;
		}
	}
	#endregion
	
}

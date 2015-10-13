using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum MOVE { UP , DOWN , LEFT, RIGHT }

public class MoveGen : MonoBehaviour {
	public Sprite up,down,left,right;
	public Image[] arrows;
	public float genInterval;

	static MOVE[] tableMut = { MOVE.UP , MOVE.DOWN , MOVE.LEFT, MOVE.RIGHT };

	public MOVE[] moves;//  { get; private set; } 
	public MOVE currentMove { 
		get {
			return moves[currentIndex];
		}
	} 

	int currentIndex;

	void Awake (){ 
		GenMove(arrows.Length);
	}

	IEnumerator _gen;

	public void StartGen () {
		if ( _gen == null ) 
			StartCoroutine( _gen = Gen() );
	}

	public void StopGen () {
		if ( _gen != null ) {
			StopCoroutine(_gen);
			_gen = null;
		}
	}

	void OnGUI () {
		if ( GUILayout.Button("Start Gen") ) {
			StartGen();
		}
		if ( GUILayout.Button("Stop Gen") ) {
			StopGen();
		}
	}

	IEnumerator Gen () {
		while (true ) {
			yield return new WaitForSeconds(genInterval);
			GenMove(1);
		}
	}

	void GenMove (int nb ) {
		while ( nb > 0 ) {
			moves[currentIndex = ( (currentIndex+1) % moves.Length )]  = tableMut[Random.Range(0,tableMut.Length)];
			nb --;
		}
	}
	
}

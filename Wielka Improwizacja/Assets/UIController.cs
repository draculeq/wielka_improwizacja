using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	#region hide
	private static UIController _instance;
	public static UIController Instance {
		get {
			if ( _instance == null ) {
				_instance = GameObject.FindObjectOfType(typeof(UIController)) as UIController;
			}
			return _instance;
		}
	}
	#endregion

	[SerializeField] Text left_score;
	[SerializeField] Text right_score;

	public void DisplayLeftScore ( int p ) {
		left_score.text = "Scores: " + p;
	}

	public void DisplayRightScore ( int p ) {
		right_score.text = "Scores: " + p;
	}

}

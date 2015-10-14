using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
   [SerializeField]
    private Text _text;
    // Use this for initialization
    void Start()
    {
        _text.text = "Score: 0";
    }

    public void DisplayPoint(int obj)
    {
		_text.text = "Score: " + obj;
		Debug.Log("ASD2");
	}
}

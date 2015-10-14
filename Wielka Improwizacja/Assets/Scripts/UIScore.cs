using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    public PointCounter _counter;
    [SerializeField]
    private Text _text;
    // Use this for initialization
    void Start()
    {
        _counter.PointAdded += _counter_PointAdded;
		Debug.Log("counter event null? = " + _counter.NullCheck());
        _text.text = "Score: 0";
		Debug.Log("ASD");
    }

    private void _counter_PointAdded(int obj)
    {
		_text.text = "Score: " + obj;
		Debug.Log("ASD2");
	}
}

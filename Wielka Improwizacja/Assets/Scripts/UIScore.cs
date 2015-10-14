using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    [SerializeField]
    private PointCounter _counter;
    [SerializeField]
    private Text _text;
    // Use this for initialization
    void Start()
    {
        _counter.PointAdded += _counter_PointAdded;
        _text.text = "Score: 0";
    }

    private void _counter_PointAdded(int obj)
    {
        _text.text = "Score: " + obj;
    }
}

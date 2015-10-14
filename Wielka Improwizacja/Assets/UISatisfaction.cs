using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UISatisfaction : MonoBehaviour
{
    public Image fill;
    public Color green;
    public Color red;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fill.fillAmount = AudienceSatisfaction.Instance.Satisfaction / 100;
        fill.color = Color.Lerp(green, red, 1 - AudienceSatisfaction.Instance.Satisfaction / 100);
    }
}

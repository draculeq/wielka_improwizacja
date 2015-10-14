using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UISatisfaction : MonoBehaviour
{
    public Image fill;
    public Color green;
    public Color red;
    public ParticleSystem particle;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (AudienceSatisfaction.Instance.Satisfaction >= 100 && (particle.isStopped || particle.isPaused))
        {
            Debug.Log("play");
            particle.Play();
        }
        else if (particle.isPlaying && AudienceSatisfaction.Instance.Satisfaction < 100)
        {
            Debug.Log("stop");
            particle.Stop();
        }

        fill.fillAmount = AudienceSatisfaction.Instance.Satisfaction / 100;
        fill.color = Color.Lerp(green, red, 1 - AudienceSatisfaction.Instance.Satisfaction / 100);
    }
}

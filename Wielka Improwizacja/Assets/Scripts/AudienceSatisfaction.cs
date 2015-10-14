using UnityEngine;

public class AudienceSatisfaction : MonoBehaviour
{
    public static AudienceSatisfaction Instance;
    public float Satisfaction = 50;
    public float Speed;
    public float punishment;
    public float reward;
    public float winTimer;
    // Use this for initialization
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Satisfaction -= Speed * Time.deltaTime;
        if (Satisfaction < 0)
        {
            Debug.Log("GAME OVER");
            enabled = false;
        }

        if (Satisfaction < 100)
            winTimer = -1;
        if (winTimer == -1 && Satisfaction > 100)
            winTimer = 0;
        if (winTimer >= 0 && Satisfaction > 100)
            winTimer += Time.deltaTime;
        if (winTimer >= 10)
        {
            enabled = false;
            Debug.Log("Wictory");
        }
    }

    public void Good()
    {
        if (enabled == false) return;
        Satisfaction += reward;
        Satisfaction = Mathf.Clamp(Satisfaction, -1, 110);
    }

    public void Bad()
    {
        if (enabled == false) return;
        Satisfaction -= punishment;
    }
}

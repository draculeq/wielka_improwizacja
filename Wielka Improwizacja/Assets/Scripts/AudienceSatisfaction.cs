using UnityEngine;

public class AudienceSatisfaction : MonoBehaviour
{
    public static AudienceSatisfaction Instance;
    public float Satisfaction = 50;
    public float Speed;
    public float punishment;
    public float reward;
    // Use this for initialization
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Satisfaction -= Speed * Time.deltaTime;
        if (Satisfaction<0)
            Debug.Log("GAME OVER");
    }

    public void Good()
    {
        Satisfaction += reward;
    }

    public void Bad()
    {
        Satisfaction -= punishment;
    }
}

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
			enabled = false;
			PlayerPrefs.SetInt("winner",0);
			Application.LoadLevel("game_end");
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
			var l = GameObject.FindObjectsOfType(typeof(PointCounter)) as PointCounter[];
			if ( l.Length != 2 ) throw new UnityException("more/less than 2 players in scene ?? list.Length=" + l.Length);
			int winner = 0;
			if ( l[0].totalPoints == l[1].totalPoints ) winner = 3;
			else winner = l[0].totalPoints > l[1].totalPoints ? 1 : 2;
			PlayerPrefs.SetInt("winner",winner);
			Application.LoadLevel("game_end");
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

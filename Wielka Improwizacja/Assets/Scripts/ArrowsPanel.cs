using UnityEngine;

public class ArrowsPanel : MonoBehaviour
{
    public Sprite[] ArrowsSprites;
    public UIArrow Prefab;
    public MoveGen _generator;
    // Use this for initialization
    void Start()
    {
        _generator.NewMoveGenerated += NewMoveGenerated;
    }

    private void NewMoveGenerated(MoveGen.Move move)
    {
        var arrow = Instantiate(Prefab);
        arrow.transform.SetParent(transform, true);
        arrow.Init(move, ArrowsSprites[((int)move.Direction)]);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

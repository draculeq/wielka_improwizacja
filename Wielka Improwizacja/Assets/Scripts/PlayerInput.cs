using Rewired;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private int _playerIndex;
    private Player _player;

    //public void Update()
    //{
    //    string text = _playerIndex.ToString();
    //    if (MoveDown())
    //        text += "MoveDown ";
    //    if (MoveLeft())
    //        text += "MoveLeft ";
    //    if (MoveRight())
    //        text += "MoveRight ";
    //    if (MoveUp())
    //        text += "MoveUp ";

    //    if (SkillDown())
    //        text += "SkillDown ";
    //    if (SkillLeft())
    //        text += "SkillLeft ";
    //    if (SkillRight())
    //        text += "SkillRight ";
    //    if (SkillUp())
    //        text += "SkillUp ";

    //    if (PokeDown())
    //        text += "PokeDown ";
    //    if (PokeLeft())
    //        text += "PokeLeft ";
    //    if (PokeRight())
    //        text += "PokeRight ";
    //    if (PokeUp())
    //        text += "PokeUp ";
    //    Debug.Log(text);
    //}
    void Awake()
    {
        _player = ReInput.players.GetPlayer(_playerIndex);
        if (_player==null)
            Debug.LogError("There is no player " + _playerIndex);
    }
    #region movement

    public Vector2 Movement()
    {
       Vector2 movement = new Vector2();
        if (MoveLeft()) movement.x -= 1;
        if (MoveRight()) movement.x += 1;
        if (MoveUp()) movement.y += 1;
        if (MoveDown()) movement.y -= 1;
        return movement;
    }

    public Vector2 Skill()
    {
        Vector2 skill = new Vector2();
        if (SkillLeft()) skill.x -= 1;
        if (SkillRight()) skill.x += 1;
        if (SkillUp()) skill.y += 1;
        if (SkillDown()) skill.y -= 1;
        return skill;
    }

    public Vector2 Poke()
    {
        Vector2 poke = new Vector2();
        if (PokeLeft()) poke.x -= 1;
        if (PokeRight()) poke.x += 1;
        if (PokeUp()) poke.y += 1;
        if (PokeDown()) poke.y -= 1;
        return poke;
    }
    public bool MoveLeft()
    {
        return _player.GetButton("Move_Left");
    }
    public bool MoveRight()
    {
        return _player.GetButton("Move_Right");
    }
    public bool MoveUp()
    {
        return _player.GetButton("Move_Up");
    }
    public bool MoveDown()
    {
        return _player.GetButton("Move_Down");
    }
    #endregion

    #region Skills
    public bool SkillLeft()
    {
        return _player.GetButton("Skill_Left");
    }
    public bool SkillRight()
    {
        return _player.GetButton("Skill_Right");
    }
    public bool SkillUp()
    {
        return _player.GetButton("Skill_Up");
    }
    public bool SkillDown()
    {
        return _player.GetButton("Skill_Down");
    }
    #endregion

    #region Pokes
    public bool PokeLeft()
    {
        return _player.GetButton("Poke_Left");
    }
    public bool PokeRight()
    {
        return _player.GetButton("Poke_Right");
    }
    public bool PokeUp()
    {
        return _player.GetButton("Poke_Up");
    }
    public bool PokeDown()
    {
        return _player.GetButton("Poke_Down");
    }
    #endregion
}

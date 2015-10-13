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

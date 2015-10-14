using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _input;
    private float _speed = 4;
    private MoveGen _generator;
    Animator animator;

    // Use this for initialization
    void Start()
    {
        _input = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        _generator = GetComponent<MoveGen>();
    }

    // Update is called once per frame
    void Update()
    {
        var _move = _input.Movement();

        Movement(_move);
        Animations(_move);
        Skills();
    }

    private void Movement(Vector2 _move)
    {
        transform.Translate(new Vector3(_move.x, 0, _move.y) * Time.deltaTime * _speed);
        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -6, 6), transform.localPosition.y,
            Mathf.Clamp(transform.localPosition.z, 0, 5));
    }

    private void Animations(Vector2 _move)
    {
       

        if (_input.SkillLeft())
        {
            if (animator != null) animator.Play("left");
        } else if (_input.SkillRight())
		{
			if (animator != null) animator.Play("right");
		} else if (_input.SkillDown())
        {
            if (animator != null) animator.Play("crouch");
        } else if (_input.SkillUp())
        {
            if (animator != null) animator.Play("jump");
		} else if (_move.x != 0 | _move.y != 0)
		{

			if (animator != null) {
				if ( animator.GetCurrentAnimatorStateInfo(0).IsName("idle") ) 
					animator.Play("move");
			}
		}
    }

    private void Skills()
    {
        var currentMove = _generator.currentMove;
        if (currentMove==null) return;
        if (_input.SkillLeft())
            if (currentMove.Check(MOVE.LEFT))
                Debug.Log("Left");
        if (_input.SkillRight())
            if (currentMove.Check(MOVE.RIGHT))
                Debug.Log("Right");
        if (_input.SkillUp())
            if (currentMove.Check(MOVE.UP))
                Debug.Log("Up");
        if (_input.SkillDown())
            if (currentMove.Check(MOVE.DOWN))
                Debug.Log("Down");
    }
}

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _input;
    private float _speed = 4;

	Animator animator;

    // Use this for initialization
    void Start()
    {
        _input = GetComponent<PlayerInput>();
		animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		var _move = _input.Movement();
		if ( _move.x != 0 | _move.y != 0 ) {
			if ( animator != null ) animator.Play("move");
		}
		transform.Translate(new Vector3(_move.x, 0, _move.y) * Time.deltaTime * _speed);
        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -6, 6), transform.localPosition.y, Mathf.Clamp(transform.localPosition.z, 0, 5));
		if ( _input.SkillLeft() ) { 
			if (    animator != null ) animator.Play("left");
		}

		if ( _input.SkillDown() ) {
			if ( animator != null ) animator.Play("crouch");
		}

		if ( _input.SkillUp() ) {
			Debug.Log("asda");
			if ( animator != null ) animator.Play("jump");
		}
	}
}

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _input;
    private float _speed = 4;
    // Use this for initialization
    void Start()
    {
        _input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(_input.Movement().x, 0, _input.Movement().y) * Time.deltaTime * _speed);
        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -6, 6), transform.localPosition.y, Mathf.Clamp(transform.localPosition.z, 0, 5));
    }
}

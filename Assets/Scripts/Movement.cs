using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private InputController _input;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;

    private Vector3 _movement;
    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        _movement = new Vector3(_input.horizontal, 0.0f, _input.vertical);
        _controller.SimpleMove(_speed * _movement * Time.fixedDeltaTime);
        _animator.SetFloat("speed", _movement.z);
    }
}

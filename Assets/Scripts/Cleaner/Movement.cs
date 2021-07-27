using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private InputController _input;
    [SerializeField] private Transform _trans;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private Vector3 _movement;
    private bool canMove = true;

    private void Update()
    {
        if(_input.jump && canMove)
        {
            _animator.SetTrigger("jump");
        }
    }

    private void FixedUpdate()
    {
        if(canMove)
        {
            Move();
            Rotate();
        }
    }

    private void Move()
    {
        _movement = _speed * _trans.forward * _input.vertical;
        if(_input.vertical > 0.1)
        {
            _controller.Move(_movement * Time.fixedDeltaTime);
        }
        else if(_input.vertical < -0.1)
        {
            _controller.Move(_movement * 0.5f * Time.fixedDeltaTime);
        }
        
        _animator.SetFloat("speed", _input.vertical);
    }

    private void Rotate()
    {
        _trans.Rotate(Vector3.up * _input.horizontal * Time.fixedDeltaTime * _rotationSpeed);
    }

    public void SetMovingPossibility(bool isPossible)
    {
        canMove = isPossible;
    }
}

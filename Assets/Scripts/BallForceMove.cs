using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForceMove : MonoBehaviour
{
    [SerializeField] private float _moveForce = 5.0f;

    private Rigidbody _rigidbody;
    private Camera _camera;

    private bool _isMoving;

    private string _horizontalAxisName = "Horizontal";
    private string _verticalAxisName = "Vertical";
    private Vector3 _inputVector;

    private float _velocityDeacceleration = 0.2f;
    private float _deaccelerationX;
    private float _deaccelerationY;

    private BallJump _ballJump;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _camera = GetComponent<Camera>();
        _ballJump = GetComponent<BallJump>();
    }

    private void Update()
    {
        if (_inputVector != Vector3.zero)
            _isMoving = true;
        else
            _isMoving = false;

        HandleMoveDirection();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_isMoving == true)
            _rigidbody.AddForce(_inputVector * _moveForce, ForceMode.Force);
        if (_isMoving == false && _ballJump.IsGrounded == true)
            _rigidbody.velocity = new Vector3(Mathf.SmoothDamp(_rigidbody.velocity.x, 0, ref _deaccelerationX, _velocityDeacceleration), 0, Mathf.SmoothDamp(_rigidbody.velocity.z, 0, ref _deaccelerationY, _velocityDeacceleration));
    }

    private void HandleMoveDirection()
    {
        float xInput = Input.GetAxisRaw(_horizontalAxisName);
        float yInput = Input.GetAxisRaw(_verticalAxisName);

        _inputVector = new Vector3(xInput,0,yInput).normalized;
    }
}

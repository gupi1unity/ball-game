using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    private Rigidbody _rigidbody;
    public bool IsGrounded { get; private set; } = true;

    private bool _isJumping;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CheckIsJumping();
        CheckIsGrounded();
    }

    private void FixedUpdate()
    {
        if (IsGrounded == true && _isJumping == true)
            Jump();
    }

    private void CheckIsGrounded()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, 0.5f))
            IsGrounded = true;
        else
            IsGrounded = false;
    }

    private void CheckIsJumping()
    {
        if (Input.GetKey(KeyCode.Space))
            _isJumping = true;
        else
            _isJumping = false;
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }
}

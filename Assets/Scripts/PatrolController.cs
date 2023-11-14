using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PatrolController : MonoBehaviour
{
    [Header("Move")]
    [SerializeField]
    float moveSpeed = 300.0F;

    //------------------------------//

    [SerializeField]
    Transform groundCheck;

    //piso
    [SerializeField]
    LayerMask groundMask;

    //------------------------------//

    [SerializeField]
    Transform groundEndCheck;

    [SerializeField]
    LayerMask groundEndMask;

    [Header("Animation")]
    [SerializeField]
    Animator animator;

    Rigidbody2D _rb;

    Vector2 _direction;

    bool _isMoving;

    float _gravityY;

    float movimiento = 0.1F; //Por defecto se asigna hacia la derecha

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _gravityY = -Physics.gravity.y;
    }

    void Update()
    {
        HandleInputs(movimiento);
    }

    void FixedUpdate()
    {
        HandleFlipX();
        HandleMove();
    }

    void HandleInputs(float movimiento)
    {
        _direction = new Vector2(movimiento, 0.0F);
        _isMoving = _direction.x != 0.0F;
    }

    void HandleMove()
    {
        bool isMoving = animator.GetFloat("speed") > 0.01F;

        if (_isMoving != isMoving)
        {
            animator.SetFloat("speed", Mathf.Abs(_direction.x));
        }

        Vector2 velocity = _direction * moveSpeed * Time.fixedDeltaTime;
        velocity.y = _rb.velocity.y;
        _rb.velocity = velocity;
    }

    void HandleFlipX()
    {
        if (!_isMoving)
        {
            return;
        }

        if (IsEndGrounded())
        {
            return;
        }
        else
        { 
            transform.Rotate(0.0F, 180.0F, 0.0F);
            movimiento = -movimiento;
        }
    }

    bool IsGrounded()
    {
        return
        Physics2D.OverlapCapsule
            (groundCheck.position, new Vector2(1.25F, 0.65F),
                CapsuleDirection2D.Horizontal, 0.0F, groundMask);
    }

    bool IsEndGrounded()
    {
        return
        Physics2D.OverlapCapsule
            (groundEndCheck.position, new Vector2(1.25F, 0.99F),
                CapsuleDirection2D.Horizontal, 0.0F, groundEndMask);
    }
}


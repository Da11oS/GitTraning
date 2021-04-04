using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Move : MonoBehaviour
{
    private Rigidbody2D _rb;

    // ����������, �����������  ������������ ��������� �� ��� � � y
    private float JumpForce = 7f;
    private float Speed;
    private Vector2 moveVector;


    //���������� ��� �������� ��������� �� ��������������� � �������������
    [SerializeField] private Transform GroundCheck; //���������� ����������� �� �����
    [SerializeField] private LayerMask Ground; //������ �� ���� "Ground"
    private bool IsGrounded; //��������� ��������� �� ��������������� � ������������� � ����� "Ground"
    private float CheckRadius = 0.5f; // ������ ��� ���������� ��������������� �  �������������

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        OnGroundCheck();
        JumpLogic(); // ��������� ������ 
    }
    void FixedUpdate()
    {
        MovementLogic(); //��������� ����������� �� ��� �, � ����� ��������� ��� ������� ������ shift

    }

    private void MovementLogic()
    {
        Speed = 10f;
        moveVector.x = Input.GetAxis("Horizontal");
        if(Input.GetButton("Fire3"))
        {
            Speed = 12f;
        }
        _rb.velocity = new Vector2(moveVector.x * Speed, _rb.velocity.y);
    }

    private void JumpLogic()
    {
        if (Input.GetButtonDown("Jump")&&IsGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, JumpForce);
           
        }
    }
        
    private void OnGroundCheck()
    {
        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, Ground);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

               public enum States
{
    chill,
    walk
};
public class Hero_Move : MonoBehaviour
{

    private States State
    {
        get { return (States)_anim.GetInteger("State"); }
        set {  _anim.SetInteger(("State"), (int)value); }

    }
    private Rigidbody2D _rb;
    private Animator _anim;
    private SpriteRenderer sprite;

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
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
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
        if (_rb.velocity!= Vector2.zero) _anim.Play("char_walk");
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

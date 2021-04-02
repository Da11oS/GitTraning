using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Move : MonoBehaviour
{
    private Rigidbody2D _rb;

    // переменные, реализующие  передвижение персонажа по оси х и y
    private float JumpForce = 7f;
    private float Speed;
    private Vector2 moveVector;


    //переменные для проверки персонажа на соприкосновение с поверхностями
    [SerializeField] private Transform GroundCheck; //нахождение поверхности на сцене
    [SerializeField] private LayerMask Ground; //ссылка на слой "Ground"
    private bool IsGrounded; //проверяет персонажа на соприкосновение с поверхностями с тегом "Ground"
    private float CheckRadius = 0.5f; // радиус для нахождения соприкосновения с  поверхностями

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        OnGroundCheck();
        JumpLogic(); // реализует прыжок 
    }
    void FixedUpdate()
    {
        MovementLogic(); //реализует перемещение по оси х, а также ускорение при нажатии левого shift

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

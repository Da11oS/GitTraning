using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum Animations
{
    Stay,
    Move,
    Attack
}
public class Hero_Move : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animations _currentAnimation = 0;

    // переменные, реализующие  передвижение персонажа по оси х и y
    [SerializeField] private float JumpForce = 7f;
    [SerializeField] private float Speed;
    private float _runSpeed;
    private Vector2 moveVector;

    public Transform punch;
    public float punchRadius;

    //переменные для проверки персонажа на соприкосновение с поверхностями
    [SerializeField] private Transform GroundCheck; //нахождение поверхности на сцене
    [SerializeField] private LayerMask Ground; //ссылка на слой "Ground"
    private Animator _anim;
    private SpriteRenderer _spriteRenderer;
    private bool IsGrounded; //проверяет персонажа на соприкосновение с поверхностями с тегом "Ground"
    private float CheckRadius = 0.5f; // радиус для нахождения соприкосновения с  поверхностями

    void Start()
    {
        _runSpeed = Speed * 1.5f;
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        MovementLogic(); //реализует перемещение по оси х, а также ускорение при нажатии левого shift
        JumpLogic(); // реализует прыжок 
        OnGroundCheck();
        if (Input.GetMouseButtonDown(0))
        {
            if (_anim.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Attack 1")
            {
                Action(punch.position, punchRadius, 7, 3);
                Debug.Log("WE ARE ATTTTTTTACK!");
                _currentAnimation = Animations.Attack;
            }
        }
        State((int)_currentAnimation);
    }
    void FixedUpdate()
    {
    }

    private void MovementLogic()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        if(Input.GetButton("Fire3"))
        {
            _rb.velocity = new Vector2(moveVector.x * _runSpeed, _rb.velocity.y);
        }
        _rb.velocity = new Vector2(moveVector.x * Speed, _rb.velocity.y);

        if(_rb.velocity.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if(_rb.velocity.x < 0)
        {
            _spriteRenderer.flipX = true;
        }

        if(_rb.velocity.x != 0)
        {
                _currentAnimation = Animations.Move;
        }
        else
        {
                _currentAnimation = Animations.Stay;
        }
    }

    private void JumpLogic()
    {
        if (Input.GetButtonDown("Jump")&&IsGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, JumpForce); 
                _currentAnimation = Animations.Stay;
        }
    }
        
    private void State(int value)
    {
        _anim.SetInteger("State", value);
    }

    private void OnGroundCheck()
    {
        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, Ground);
    }

    public static void Action(Vector2 point, float radius, int layerMask, float damage)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(point, radius, 1 << layerMask);

        foreach (Collider2D hit in colliders)
        {
            if (hit.GetComponent<Enemy>())
            {
                hit.GetComponent<Enemy>().GetDamage(damage);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public float Level;

    [SerializeField] protected float _forceJump;

    private float _timer = 0;

    private bool _isDefense = false;

    [SerializeField] private float _durationJump = 1;
    [SerializeField] private float _currentHigthJump = 0;
    void Start()
    {
        _moveSpeed += Random.Range(0.2f, 1.5f);
        _helth *= Level;
        _damage *= Level;
        _forceJump += Random.Range(0.2f, 1.5f);
        _reloadAttackTime *= Level / 2;
        transform.localScale = Vector3.one * Random.Range(Level - 0.2f, Level + 0.2f);
    }

    void FixedUpdate()
    {
        ActionEnemy();
        if (_isDefense || (_helth < _maxHelth * 0.2 && _distanceEnemyToPlayer < _rangeAttack * 2))
        {
            _isDefense = true;
            Defence();
            if (_helth > _maxHelth * 0.5)
            {
                _isDefense = false;
            }
        }
        if (Random.Range(0,10) > 8 && _rb.velocity.y == 0)
        {
            _timer = 0;
            Jump();
        }
    }

    private void Jump()
    {
        _timer += Time.deltaTime * _durationJump;
        _currentHigthJump = -Mathf.Pow(_timer, 2) + _forceJump;
        _rb.velocity = new Vector2(_rb.velocity.x, _currentHigthJump);
    }

    private void Defence()
    {
        _helth += Time.deltaTime * _maxHelth * 0.02f; 
    }
}

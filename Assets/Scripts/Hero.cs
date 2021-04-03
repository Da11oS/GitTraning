using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField]private float _helth = 5;

    void Update()
    {
        if (_helth <= 0)
        {
            YouAreDead();
        }
    }
    private void YouAreDead()
    {
        Destroy(gameObject);
    }

    public float GetHelth()
    {
        return _helth;
    }
    public void GetDamage(float damage)
    {
        _helth -= damage;
    }


}

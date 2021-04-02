using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float MoveSpeed;
    public int PositionOfPatrol;
    public Transform Point;
    bool MovingRight;

    public float HP = 100;

    Transform player;
    public float stoppingDistance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, Point.position) < PositionOfPatrol)
        {
            Chill();
        }

        
    }

    void Chill()
    {
        if(transform.position.x > Point.position.x + PositionOfPatrol)
        {
            MovingRight = false;
        }
        else if(transform.position.x < Point.position.x + PositionOfPatrol)
        {
            MovingRight = true;
        }

        if(MovingRight)
        {
            transform.position = new Vector2(transform.position.x + MoveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - MoveSpeed * Time.deltaTime, transform.position.y);
        }
    }

    void Attack()
    {

    }

    void GoBack()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_movement : MonoBehaviour
{
    public Transform player_trans;
    [SerializeField] float moveSpeed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer spr;
    private Vector2 movement;
    Vector3 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        try
        {
            direction = player_trans.position - transform.position;
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //rb.rotation = angle;
            if (player_trans.position.x > transform.position.x)
            {
                spr.flipX = false;
            }
            else if (player_trans.position.x < transform.position.x)
            {
                spr.flipX = true;
            }
            direction.Normalize();
            movement = direction;
        }
        catch
        {

        }
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}

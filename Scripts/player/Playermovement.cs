using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float moveSpeed = 9.4f;
    public Rigidbody2D rb;
    private SpriteRenderer spr;
    [SerializeField]private Transform guntran;
    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if(transform.position.x > mousePos.x)
        {
            spr.flipX = true;
            guntran.position = new Vector2(transform.position.x - 0.2f, transform.position.y);
        }else if (transform.position.x < mousePos.x)
        {
            spr.flipX = false;
            guntran.position = new Vector2(transform.position.x + 0.2f, transform.position.y);
        }

    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement*moveSpeed* Time.fixedDeltaTime);
    }
}

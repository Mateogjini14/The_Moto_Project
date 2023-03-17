using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_health : MonoBehaviour
{
    [SerializeField] private int enemy_health = 5;
    [SerializeField] private int damage_take = 1;
    //float timeColliding;
    //public float timeThreshold = 0.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "projectile")
        {
            //timeColliding = 0f;
            enemyDamage();
        }
    }
    /*          Might want some over time dmg to enemies
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            if (timeColliding < timeThreshold)
            {
                timeColliding += Time.deltaTime;
            }
            else
            {
                playerDamage(1);
                timeColliding = 0f;
            }
        }
    }
    */
    private void die()
    {
        Destroy(gameObject);
        //death animation
    }
    private void enemyDamage()
    {
        enemy_health -= damage_take;
        if (enemy_health <= 0f)
        {
            die();
        }
    }
}

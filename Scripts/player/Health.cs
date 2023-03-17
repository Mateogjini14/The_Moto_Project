using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public static Health Instance;

    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite full_heart;
    [SerializeField] private Sprite half_heart;
    [SerializeField] private Sprite empty_heart;
    [SerializeField] private int health = 10;
    private int num_hearts;
    private int num_halfHeart;
    float timeColliding;
    public float timeThreshold = 0.5f;
    
    private void Awake() //not needed for now used to connect health script with enemy script
    {
        Instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "healup")
        {
            if (health < 10)
            {
                health += 2;                        //heal 2 cuz sprite is a full heart obviously that can change
                if (health > hearts.Length * 2)     //fix maxhealth to the amount of hearts in screen
                {
                    health = hearts.Length * 2;
                }
                Destroy(collision.gameObject);
            }
            display_hearts();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            timeColliding = 0f;
            playerDamage(1);
        }
    }

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

    private void die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Gamescene");
        //death animation
    }
    private void playerDamage(int amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            die();
        }

        display_hearts();

    }

    private void display_hearts()
    {
        num_hearts = (health / 2); //number of full hearts
        num_halfHeart = health % 2; //number of half hearts can be 1 or 0

        if (num_halfHeart == 1) //if there will be a half heart make place for it
        {
            num_hearts += 1;
        }

        for (int i = 0; i < hearts.Length; i++) //go through the heart objects
        {
            if (i < num_hearts) //check if index hearts[i] should be rendered
            {
                if (i * 2 + 1 == health) //check if half or full heart should be rendered
                {
                    hearts[i].sprite = half_heart;
                }
                else
                {
                    hearts[i].sprite = full_heart;
                }
            }
            else
            {
                hearts[i].sprite = empty_heart;
            }
        }
    }

}

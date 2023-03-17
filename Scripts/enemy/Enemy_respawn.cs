using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_respawn : MonoBehaviour
{
    [SerializeField] GameObject zombiePrefab;
    [SerializeField] GameObject ghostPrefab;
    [SerializeField] GameObject slimePrefab;
    [SerializeField] GameObject waterSlimePrefab;
    [SerializeField] Transform respawnpoint1;
    [SerializeField] Transform respawnpoint2;
    [SerializeField] Transform respawnpoint3;
    [SerializeField] Transform respawnpoint4;
    
    [SerializeField] Transform player;

    [SerializeField] float respawnTimeZombie = 3;
    [SerializeField] float respawnTimeGhost;
    [SerializeField] float respawnTimeSlime;
    [SerializeField] float respawnTimeWaterSlime;
    float timeZombie = 0;
    float timeGhost = 0;
    float timeSlime = 0;
    float timeWaterSlime = 0;

    void Start()
    {
        //Vector3 point1 = new Vector3(respawnpoint1.position.x, respawnpoint1.position.y, 0);  // For some reason instatiating objects with spawnpoint.position makes objects invisible
        //Vector3 point2 = new Vector3(respawnpoint2.position.x, respawnpoint2.position.y, 0);  // so using vector 3 collect x y z data and use them instead
        //Vector3 point3 = new Vector3(respawnpoint3.position.x, respawnpoint3.position.y, 0);  // inside the functions cuz why not
        //Vector3 point4 = new Vector3(respawnpoint4.position.x, respawnpoint4.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeZombie > respawnTimeZombie)
        {
            respawnZombie();
            timeZombie = 0;
        }
        if (timeGhost > respawnTimeGhost)
        {
            respawnGhost();
            timeGhost = 0;
        }
        if (timeSlime > respawnTimeSlime)
        {
            respawnSlime();
            timeSlime = 0;
        }
        if (timeWaterSlime > respawnTimeWaterSlime)
        {
            respawnWaterSlime();
            timeWaterSlime = 0;
        }
        timeZombie += Time.deltaTime;
        timeGhost += Time.deltaTime;
        timeSlime += Time.deltaTime;
        timeWaterSlime += Time.deltaTime;
    }

    void respawnZombie()
    {
        Vector3 point1 = new Vector3(respawnpoint1.position.x, respawnpoint1.position.y, 0);
        GameObject Zombie = Instantiate(zombiePrefab, point1, Quaternion.identity);
        Zombie.GetComponent<Zombie_movement>().player_trans = player.transform;

    }

    void respawnGhost()
    {
        Vector3 point2 = new Vector3(respawnpoint2.position.x, respawnpoint2.position.y, 0);
        GameObject Ghost = Instantiate(ghostPrefab, point2, Quaternion.identity);
        Ghost.GetComponent<Zombie_movement>().player_trans = player.transform;
    }

    void respawnSlime()
    {
        Vector3 point3 = new Vector3(respawnpoint3.position.x, respawnpoint3.position.y, 0);
        GameObject Slime = Instantiate(slimePrefab, point3, Quaternion.identity);
        Slime.GetComponent<Zombie_movement>().player_trans = player.transform;
    }

    void respawnWaterSlime()
    {
        Vector3 point4 = new Vector3(respawnpoint4.position.x, respawnpoint4.position.y, 0);
        GameObject WaterSlime = Instantiate(waterSlimePrefab, point4, Quaternion.identity);
        WaterSlime.GetComponent<Zombie_movement>().player_trans = player.transform;
    }
}

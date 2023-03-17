using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FirstGearGames.SmoothCameraShaker;

public class shooting : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform gunpoint;
    public ShakeData myshake;
    public GameObject bulletPrefab;
    [SerializeField] private ParticleSystem prtcl;
    [SerializeField] private Transform prtclTrans;
    public float bulletforce = 20f;
    [SerializeField] float fireRatio = 0.7f;
    float time = 100; // bigger than fireRatio so first bullet shoots immediatly
    void Update()
    {
        if (Input.GetButton("Fire1")) 
        {
            if (time > fireRatio)
            {
                Shoot();
                time = 0;
                CameraShakerHandler.Shake(myshake);
            }
            time += Time.deltaTime;
            
        }

    }
    void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, gunpoint.position, gunpoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(gunpoint.up * bulletforce, ForceMode2D.Impulse);

        prtclTrans.position = new Vector2(gunpoint.transform.position.x, gunpoint.transform.position.y);
        prtcl.Play();
    }
}

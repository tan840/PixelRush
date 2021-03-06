﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletLifetime;

   

    public int damage;


    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(DeactiveBulletCoroutine());
    }
    
    IEnumerator DeactiveBulletCoroutine()
    {
        yield return new WaitForSeconds(bulletLifetime);
        DeactiveBullet();
    }
    void DeactiveBullet()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            print("hit");
            collision.GetComponent<Enemy>().TakeDamage(damage);
            this.gameObject.SetActive(false);
           
        }
    }
}

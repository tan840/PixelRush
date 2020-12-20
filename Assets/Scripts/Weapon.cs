using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cameraMain;

    //fireMechanics
    public GameObject projectile;
    public Transform projectilePos;
    public float timeBetweenShots;
    public List<GameObject> bulletList= new List<GameObject>();

    public Transform bulletParent;

    private float shotTime;

    



    private void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            InstantiateBullets();
        }
    }

    void InstantiateBullets()
    {
        GameObject bullets = Instantiate(projectile, projectilePos.position, transform.rotation);
        bullets.SetActive(false);
        bullets.transform.parent = bulletParent.transform;
        bulletList.Add(bullets);
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 direction = cameraMain.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
        transform.rotation = rotation;

        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time>shotTime)
            {
                //Instantiate(projectile, projectilePos.position, transform.rotation);
                for (int i = 0; i < bulletList.Count; i++)
                {
                    if (!bulletList[i].activeInHierarchy)
                    {
                        bulletList[i].transform.position = projectilePos.transform.position;
                        bulletList[i].transform.rotation = this.transform.rotation;
                        bulletList[i].SetActive(true);
                        break;
                    }

                    else
                    {
                        GameObject bullets = Instantiate(projectile, projectilePos.position, transform.rotation);

                        bulletList.Add(bullets);                     
                        bullets.transform.parent = bulletParent.transform;
                        bullets.transform.rotation = this.transform.rotation;

                    }

                    
                }
                shotTime = Time.time + timeBetweenShots;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(1); ;
            gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartBullet : Bullet
{
    public float speed;
    public float damage;
    public float timeToDestroy;
    public GameObject bulletMesh;
    public bool isCollided;
    void Start()
    {
        StartCoroutine("Destroy");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isCollided == false)
            gameObject.transform.position += gameObject.transform.forward * (speed / 100);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Sensor" && other.gameObject != shootingObject && other.gameObject.tag != "Bullet" && isCollided == false)
        {
            isCollided = true;
            if (other.transform.GetComponent<HitBox>() != null)
            {
                other.transform.GetComponent<HitBox>().ObjectHealth.GetDamage(damage);
            }
            Destroy(bulletMesh);
            Destroy(gameObject, 3f);
        }

    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(timeToDestroy);
        if (isCollided == false)
        {
            Destroy(gameObject);
        }
    }
}
public abstract class Bullet : MonoBehaviour
{
    public GameObject shootingObject;
}

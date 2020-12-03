 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public LayerMask collisionMask;
    float speed = 10f;
    float damage = 1;

    float lifetime = 3   ;
    float skinWidth = 0.1f;


    void Start()
    {
        Destroy(gameObject, lifetime);

        Collider[] iniTialCollisions = Physics.OverlapSphere(transform.position, .1f, collisionMask);
        if (iniTialCollisions.Length > 0)
        {
            OnHitObject(iniTialCollisions[0]);

        }
    } 

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;

    }
    void Update()
    {
        float moveDistance = speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * moveDistance); 

    }

    void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast (ray, out hit, moveDistance + skinWidth, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);

        }
    }

    void OnHitObject(RaycastHit hit)
    {
        IDamageable damagebaleObject = hit.collider.GetComponent<IDamageable>();
        if (damagebaleObject != null)
        {
            damagebaleObject.TakeHit(damage, hit);
        }
        GameObject.Destroy(gameObject);
    }

    void OnHitObject(Collider c)
    {
        IDamageable damagebaleObject = c.GetComponent<IDamageable>();
        if (damagebaleObject != null)
        {
            damagebaleObject.TakeDamage(damage);
        }
        GameObject.Destroy(gameObject);
    }
}

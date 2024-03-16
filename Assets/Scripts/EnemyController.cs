using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;
    private Transform target;

    public float damage;
    public float hitWaitTime = 1f;
    public float hitCounter;
    
    void Start()
    {
        //target = FindAnyObjectByType<PlayerController>().transform;
        target = PlayerHealthController.instance.transform;
    }
    void Update()
    {
        theRB.velocity = (target.position - transform.position).normalized * moveSpeed;
        if (hitCounter > 0)
        {
            hitCounter -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && hitCounter <= 0)
        {
            PlayerHealthController.instance.TakeDamage(damage);
            hitCounter = hitWaitTime;
        }
    }
}

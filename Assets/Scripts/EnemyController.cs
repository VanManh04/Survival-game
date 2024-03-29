using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;
    private Transform target;

    public float damage;
    public float hitWaitTime = 1f;
    public float hitCounter;

    public float health = 5f;

    public float knockBackTime = .5f;
    private float knockbackCounter;

    public int expToGive = 1;

    public int coinValues = 1;
    public float coinDropRate = .5f;
    void Start()
    {
        //target = FindAnyObjectByType<PlayerController>().transform;
        target = PlayerHealthController.instance.transform;
    }
    void Update()
    {
        if (PlayerController.instance.gameObject.activeSelf == true)
        {
            if (knockbackCounter > 0)
            {
                knockbackCounter -= Time.deltaTime;

                if (moveSpeed > 0)
                {
                    moveSpeed = -moveSpeed * 2;
                }

                if (knockbackCounter <= 0)
                {
                    moveSpeed = Mathf.Abs(moveSpeed * .5f);
                }
            }

            theRB.velocity = (target.position - transform.position).normalized * moveSpeed;
            if (hitCounter > 0)
            {
                hitCounter -= Time.deltaTime;
            }
        }
        else
        {
            theRB.velocity = new Vector2(0, 0);
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

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;

        if (health <= 0)
        {
            Destroy(gameObject);

            ExperienceLeverController.instance.SpawnExp(transform.position, expToGive);

            if (Random.value <= coinDropRate)
            {
                CoinController.instance.DropCoin(transform.position, coinValues);
            }

            SFXManager.instance.PlaySFXPitched(0);
        }else
        {
            SFXManager.instance.PlaySFXPitched(1);
        }
        DamageNumberController.instance.SpawnDamage(damageToTake, transform.position);
    }

    public void TakeDamage(float damageToTake, bool shouldKnockback)
    {
        TakeDamage(damageToTake);

        if (shouldKnockback)
        {
            knockbackCounter = knockBackTime;
        }
    }
}

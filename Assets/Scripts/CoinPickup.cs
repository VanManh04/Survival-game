using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int coinAmount=1;

    private bool movingToPlayer;
    public float moveSpeed;

    public float timeBetweenChecks = .2f;
    private float checkCounter;

    private PlayerController player;
    void Start()
    {
        player = PlayerController.instance;
    }

    void Update()
    {
        if (movingToPlayer == true)
        {
            //transform.position = Vector3.MoveTowards(transform.position, PlayerHealthController.instance.transform.position, moveSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            checkCounter -= Time.deltaTime;
            if (Vector3.Distance(transform.position, player.transform.position) < player.pickupRange)
            {
                movingToPlayer = true;
                moveSpeed += player.moveSpeed;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CoinController.instance.AddCoins(coinAmount);
            Destroy(gameObject);
        }
    }
}

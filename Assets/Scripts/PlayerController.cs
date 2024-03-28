using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private void Awake()
    {
        instance = this;
    }

    public float moveSpeed;
    public Animator anim;

    public float pickupRange = 1.5f;

    public Weapon activeWeapon;
    void Start()
    {

    }
    void Update()
    {
        Vector3 moveInput = new Vector3(0f, 0f, 0f);
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();//move cheo bang move 2 huong
        transform.position += moveInput * moveSpeed * Time.deltaTime;

            anim.SetBool("isMoving", moveInput != Vector3.zero);
    }
}

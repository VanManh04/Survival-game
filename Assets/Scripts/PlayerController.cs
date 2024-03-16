using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Animator anim;

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

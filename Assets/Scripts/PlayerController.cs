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

    //public Weapon activeWeapon;

    public List<Weapon> unassignedWeapons, assignedWeapons;

    public int maxWeapons;

    //[HideInInspector]
    public List<Weapon> fullyLevelledWeapons = new List<Weapon>();

    void Start()
    {
        if (assignedWeapons.Count == 0)
        {
            AddWeapon(Random.Range(0, unassignedWeapons.Count));
        }
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

    public void AddWeapon(int weaponNumber)
    {
        if(weaponNumber<unassignedWeapons.Count)
        {
            assignedWeapons.Add(unassignedWeapons[weaponNumber]);

            unassignedWeapons[weaponNumber].gameObject.SetActive(true);
            unassignedWeapons.RemoveAt(weaponNumber);
        }
    }

    public void AddWeapon(Weapon weaponToAdd)
    {
        weaponToAdd.gameObject.SetActive(true);

        assignedWeapons.Add(weaponToAdd);
        unassignedWeapons.Remove(weaponToAdd);
    }
}

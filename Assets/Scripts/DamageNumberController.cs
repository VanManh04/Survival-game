using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumberController : MonoBehaviour
{
    public static DamageNumberController instance;

    public DamageNumber numberToSpawn;
    public Transform numberCanvas;

    [SerializeField]private List<DamageNumber> numberPool = new List<DamageNumber>();

    private void Awake()
    {
        instance = this; 
    }
    void Start()
    {
        
    }
    void Update()
    {

    }

    public void SpawnDamage(float damageAmount, Vector3 location)
    {
        int rounded = Mathf.RoundToInt(damageAmount);

        //DamageNumber newDamage = Instantiate(numberToSpawn, location, Quaternion.identity, numberCanvas);
        DamageNumber newDamage = GetFormPool();
        newDamage.Setup(rounded);
        newDamage.gameObject.SetActive(true);
        newDamage.transform.position = location;
    }

    private DamageNumber GetFormPool()
    {
        DamageNumber numberToOutput = null;
        if (numberPool.Count == 0)
        {
            numberToOutput = Instantiate(numberToSpawn, numberCanvas);
        }else
        {
            numberToOutput = numberPool[0];
            numberPool.RemoveAt(0);
        }
        return numberToOutput;
    }

    public void PlanceInPool(DamageNumber numberToPlace)
    {
        numberToPlace.gameObject.SetActive(true);
        numberPool.Add(numberToPlace);
    }
}

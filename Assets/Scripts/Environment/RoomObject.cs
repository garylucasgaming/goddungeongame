using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomObject : MonoBehaviour
{
 
    public bool isActive;
    public bool randomExistence= true;
    public Transform[] branchPath;
    public GameObject lootTable;
    public GameObject enemyTable;
    public GameObject trapTable;

    public bool isEnemy  = false;
    public bool isLoot = false;
    public bool isTrap = false;




    private void Awake()
    {

        if (randomExistence) { SetIsActive(); } else { isActive = true; }  
       

        if (isActive)
        {
            CreateObjectTable();


        }
        else {
            foreach (Transform waypoint in branchPath)
            {
                Destroy(waypoint.gameObject);
            }
            
            Destroy(this.gameObject);
        }
    }

    private void SetIsActive()
    {
        float i = UnityEngine.Random.Range(0f, 1f);
        if (i >= 0.5f)
        {
            isActive = true;
        }  else {
            isActive = false;
        }



    }



    private void CreateObjectTable()
    {
        if (randomExistence)
        {
            int i = UnityEngine.Random.Range(0, 100);

            if (i <= 33)
            {
                var table = Instantiate(lootTable, transform.position, Quaternion.identity);
                table.transform.SetParent(transform);
            }
            else if (i > 33 && i <= 66)
            {
               var table =  Instantiate(enemyTable, transform.position, Quaternion.identity);
                table.transform.SetParent(transform);
                
            }
            else if (i > 66 && i < 100)
            {
                var table = Instantiate(trapTable, transform.position, Quaternion.identity);
                table.transform.SetParent(transform);
            }
        }
        else
        {
            if (isLoot) {
                var table = Instantiate(lootTable, transform.position, Quaternion.identity);
                table.transform.SetParent(transform);
            }
            if (isEnemy)
            {
                var table = Instantiate(enemyTable, transform.position, Quaternion.identity);
                table.transform.SetParent(transform);
            }
            if (isTrap)
            {
                var table = Instantiate(trapTable, transform.position, Quaternion.identity);
                table.transform.SetParent(transform);
            }

        }



    }




}

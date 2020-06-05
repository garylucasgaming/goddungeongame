using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTable : MonoBehaviour
{

    public GameObject[] objectArray;
   

    public void Awake()
    {
        int i = Random.Range(0, objectArray.Length);
        var roomObject = Instantiate(objectArray[i], transform.position, Quaternion.identity);
        roomObject.transform.SetParent(transform);
        roomObject.GetComponent<SpriteRenderer>().sortingOrder = 1;


    }


}

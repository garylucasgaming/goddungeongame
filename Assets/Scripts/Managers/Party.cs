using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{

    public List<GameObject> heroes;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

       
    }

    public void AddToParty(GameObject  hero)
    {
        heroes.Add(hero);
        hero.transform.SetParent(transform);
       // DontDestroyOnLoad(hero);
        
    }


    public void RemoveFromParty(GameObject hero)
    {
        heroes.Remove(hero);
        Destroy(hero);
    }
}

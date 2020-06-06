using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpawner : MonoBehaviour
{
    public GameObject[] heroList;
    public GameObject canvas;
    public GameObject heroPickerUI;


    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Main Canvas");
        GenerateHeroUI();

    }

  


    private void GenerateHeroUI()
    {
        int i = UnityEngine.Random.Range(0, heroList.Length);

        var newHeroUI = Instantiate(heroPickerUI, transform.position, Quaternion.identity);
     
        newHeroUI.transform.localScale = new Vector3(1, 1, 0);
        
        
    }
}

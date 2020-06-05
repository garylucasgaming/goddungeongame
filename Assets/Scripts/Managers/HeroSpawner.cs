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
    }


    private void Start()
    {
        GenerateHeroUI();
    }

    private void GenerateHeroUI()
    {
        int i = UnityEngine.Random.RandomRange(0, heroList.Length);

        var newHeroUI = Instantiate(heroPickerUI, transform.position, Quaternion.identity);

        newHeroUI.transform.SetParent(canvas.transform);

    }
}

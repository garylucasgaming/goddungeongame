using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeroPickerUI : MonoBehaviour
{

    public GameObject hero;




    private void Awake()
    {


        transform.Find("HeroSprite").gameObject.GetComponent<SpriteRenderer>().sprite = hero.GetComponent<SpriteRenderer>().sprite;
        transform.Find("HeroStats").gameObject.GetComponent<TextMeshPro>().text = GetHeroStats(hero);
        transform.Find("HeroName").gameObject.GetComponent<TextMeshPro>().text = hero.GetComponent<Hero>().name;

    }


    private string GetHeroStats (GameObject targetHero)
    {
        var nHero = targetHero.GetComponent<Hero>();


        return "Health - " + nHero.health + " /n"
            + "Damage - " + nHero.damage + " /n"
            + "Ability - " + nHero.Ability;
    }
}

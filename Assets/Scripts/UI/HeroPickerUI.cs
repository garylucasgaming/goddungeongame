using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeroPickerUI : MonoBehaviour
{

    public GameObject hero;
    public GameObject party;
    public GameObject newHero;
    public GameObject partyUI;



    private void Awake()
    {

        party = GameObject.FindGameObjectWithTag("Party");
        partyUI = GameObject.FindGameObjectWithTag("PartyUI");
        newHero = Instantiate(hero);
        newHero.transform.SetParent(transform);
        transform.SetParent(GameObject.FindGameObjectWithTag("Main Canvas").transform);
        transform.Find("HeroSprite").gameObject.GetComponent<SpriteRenderer>().sprite = newHero.GetComponent<Hero>().sprite;
        
        transform.Find("HeroStats").GetComponent<TextMeshProUGUI>().text = GetHeroStats(newHero);
        transform.Find("HeroName").GetComponent<TextMeshProUGUI>().text = newHero.GetComponent<Hero>().heroName;

    }


    private string GetHeroStats (GameObject targetHero)
    {
        var nHero = targetHero.GetComponent<Hero>();


        return "Health - " + nHero.health + " \n"
            + "Strength - " + nHero.strength + " \n"
            + "Agility - " + nHero.agility + " \n"
            + "Intelligence - " + nHero.intelligence;
    }


    public void updateUI() {
        partyUI.gameObject.GetComponent<TownPartyUI>().UpdateUI();
    }

    public void AddHeroToParty()
    {
        
        if (party.GetComponent<Party>().heroes.Count < 4) { party.GetComponent<Party>().AddToParty(newHero); }
       

    }
}

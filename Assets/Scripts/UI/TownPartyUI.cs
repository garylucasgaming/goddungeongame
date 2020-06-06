using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TownPartyUI : MonoBehaviour
{
    
    public GameObject party;


    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Party")) { party = GameObject.FindGameObjectWithTag("Party"); }
        
        UpdateUI();
    }

    public void UpdateUI()
    {

       

        Transform panel1 = transform.Find("HeroPanel1");
        Transform panel2 = transform.Find("HeroPanel2");
        Transform panel3 = transform.Find("HeroPanel3");
        Transform panel4 = transform.Find("HeroPanel4");



        if (party && party.gameObject.GetComponent<Party>().heroes.Count > 0)
        {

            if (party.gameObject.GetComponent<Party>().heroes.Count >= 1) { SetHeroPanel(panel1, 0); SetPanelNull(panel2); SetPanelNull(panel3); SetPanelNull(panel4); }
            if (party.gameObject.GetComponent<Party>().heroes.Count >= 2) { SetHeroPanel(panel2, 1); SetPanelNull(panel3); SetPanelNull(panel4); }
            if (party.gameObject.GetComponent<Party>().heroes.Count >= 3) { SetHeroPanel(panel3, 2); SetPanelNull(panel4); }
            if (party.gameObject.GetComponent<Party>().heroes.Count >= 4) { SetHeroPanel(panel4, 3); }


            

            

        }
        else { SetPanelNull(panel1); SetPanelNull(panel2); SetPanelNull(panel3); SetPanelNull(panel4); transform.Find("PartyStats").transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>().text = ""; }

        int totalHealth = 0;
        int totalStrength = 0;
        int totalAgility = 0;
        int totalIntelligence = 0;

        if (party) {
            foreach (GameObject hero in party.gameObject.GetComponent<Party>().heroes)
            {
                totalHealth += hero.GetComponent<Hero>().health;
                totalStrength += hero.GetComponent<Hero>().strength;
                totalAgility += hero.GetComponent<Hero>().agility;
                totalIntelligence += hero.GetComponent<Hero>().intelligence;

            }

            Transform partyData = transform.Find("PartyStats");

            if (party.gameObject.GetComponent<Party>().heroes.Count > 0)
            {
                partyData.Find("Text").GetComponent<TextMeshProUGUI>().text = "Health - " + totalHealth + "  Strength - " + totalStrength + "\n" + "Agility - " + totalAgility + "  Intelligence - " + totalIntelligence;
            }
            else { partyData.Find("Text").GetComponent<TextMeshProUGUI>().text = null; }
        }


    }


    public void SetHeroPanel(Transform panel, int heroListPlace)
    {
        if (party.gameObject.GetComponent<Party>().heroes[heroListPlace])
        {
            //set sprite
            panel.Find("HeroSprite").gameObject.GetComponent<SpriteRenderer>().sprite = party.gameObject.GetComponent<Party>().heroes[heroListPlace].GetComponent<Hero>().sprite;
            //set hero data
            panel.Find("HeroData").gameObject.GetComponent<TextMeshProUGUI>().text = party.gameObject.GetComponent<Party>().heroes[heroListPlace].GetComponent<Hero>().name + "\n"
                + "Health - " + party.gameObject.GetComponent<Party>().heroes[heroListPlace].GetComponent<Hero>().health + " \n"
            + "Strength - " + party.gameObject.GetComponent<Party>().heroes[heroListPlace].GetComponent<Hero>().strength + " \n"
            + "Agility - " + party.gameObject.GetComponent<Party>().heroes[heroListPlace].GetComponent<Hero>().agility + " \n"
            + "Intelligence - " + party.gameObject.GetComponent<Party>().heroes[heroListPlace].GetComponent<Hero>().intelligence;
        }
        else { SetPanelNull(panel); }
    }


    public void SetPanelNull(Transform panel)
    {
        panel.Find("HeroSprite").gameObject.GetComponent<SpriteRenderer>().sprite = null; panel.Find("HeroData").gameObject.GetComponent<TextMeshProUGUI>().text = null;
    }


    public void RemoveFromParty(int i)
    {
        party.gameObject.GetComponent<Party>().RemoveFromParty(party.gameObject.GetComponent<Party>().heroes[i]);
        UpdateUI();
    }
}

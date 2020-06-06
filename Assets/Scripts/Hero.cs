using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Hero : MonoBehaviour
{
    public enum HeroType
    {
        Warrior,
        Thief,
        Mage
    }

    public Sprite sprite;
    public Sprite[] sprites = new  Sprite[3];
    public HeroType heroType;
    public int strength;
    public int agility;
    public int intelligence;
    public string heroName;
    public int health;

    private String[] firstNames =  new string[] {"Bril ", "Ungol ", "Sterth ", "Alevie ", "Roa ", "Herdel ",  "Jovoah ", "Khalen ", "Herad ", "Frerth ", "Zong ", "Parallax ", "Sonic ", "Choh ", "Tozu " };
    private String[] ThiefTitles = new string[] {"The Shadow", "The Dirge", "The Wanted", "The Coy",  "The Vagabond"};
    private String[] MageTitles  = new string[] {"The Wise", "The Sage", "The Vizier",  "The Sorcerer", "The  Consul" };
    private String[] WarriorTitles = new string[] { "The Bold", "The Fierce","The Brave",  "The Strong", "The Heroic" };



    private void Awake()
    {

        int x = UnityEngine.Random.Range(0, 100);
        int healthBonus = UnityEngine.Random.Range(1, 3);
        int mainStat = UnityEngine.Random.Range(4, 7);
        int secondStat = UnityEngine.Random.Range(1, 3);
        int thirdStat = UnityEngine.Random.Range(1, 2);


        if (x <= 33)
        {
            heroType = HeroType.Warrior;
        } else if (x > 33 && x <= 66)
        {
            heroType = HeroType.Thief;
        } else if (x > 66) { heroType = HeroType.Mage; } 

      

        switch (heroType)
        {
            default:
            case (HeroType.Thief):
                strength = thirdStat;
                agility = mainStat;
                intelligence = secondStat;
                sprite = sprites[2];
                break;
            case (HeroType.Mage):
                strength = thirdStat;
                agility = secondStat;
                intelligence = mainStat;
                sprite = sprites[1];
                health = -1;
                break;
            case (HeroType.Warrior):
                strength = mainStat;
                agility = secondStat;
                intelligence = thirdStat;
                sprite = sprites[0];
                health = 2;
                break;
        }

        GenerateName();


        health +=  mainStat - thirdStat - secondStat + healthBonus;


    }

    private void GenerateName()
    {
        int i = UnityEngine.Random.Range(0, firstNames.Length);
        int y = UnityEngine.Random.Range(0, 4);

        if (heroType == HeroType.Mage) { heroName = firstNames[i] + MageTitles[y]; }
        if (heroType == HeroType.Warrior) { heroName = firstNames[i] + WarriorTitles[y]; }
        if (heroType == HeroType.Thief) { heroName = firstNames[i] + ThiefTitles[y]; }

    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Hero
{
    public enum HeroType
    {
        Warrior,
        Thief,
        Mage
    }

    public HeroType heroType;
    public int strength;
    public int agility;
    public int intelligence;

    public Hero(HeroType heroType)
    {
        switch (heroType)
        {
            case (HeroType.Thief):
                strength = 2;
                agility = 6;
                intelligence = 3;
                break;
            case (HeroType.Mage):
                strength = 1;
                agility = 2;
                intelligence = 6;
                break;
            case (HeroType.Warrior):
            default:
                strength = 6;
                agility = 2;
                intelligence = 1;
                break;
        }
    }
}

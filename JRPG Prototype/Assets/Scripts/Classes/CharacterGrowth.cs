using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class CharacterGrowth
{
    public CharacterData Character;

    public void GainExp(int value)
    {
        Character.currentExp += value;

        CheckLevelUp();
    }

    public void CheckLevelUp()
    {
        if (Character.currentExp >= Character.nextExp)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        Character.maxHP = Mathf.RoundToInt(Character.maxHP * 1.1f);
        Character.attack += 1;
        Character.defense += 1;

        Character.nextExp += 200 + Mathf.RoundToInt(Character.level * 1.2f);
        Character.level += 1;
    }
}

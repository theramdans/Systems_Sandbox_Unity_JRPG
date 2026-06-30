using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerGrowth
{
    public PlayerData player;

    public void GainExp(int value)
    {
        player.CurrentExp += value;

        CheckLevelUp();
    }

    public void CheckLevelUp()
    {
        if (player.CurrentExp >= player.NextExp)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        player.MaxHP = Mathf.RoundToInt(player.MaxHP * 1.1f);
        player.BaseAttack += 1;
        player.BaseDefense += 1;

        player.NextExp += 200 + Mathf.RoundToInt(player.level * 1.2f);
        player.level += 1;
    }

}

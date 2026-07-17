using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerGrowth
{
    public void GainExp(int value, PlayerData player)
    {
        player.CurrentExp += value;

        CheckLevelUp(player);
    }

    public void CheckLevelUp(PlayerData player)
    {
        if (player.CurrentExp >= player.NextExp)
        {
            LevelUp(player);
        }
    }

    public void LevelUp(PlayerData player)
    {
        player.MaxHP = Mathf.RoundToInt(player.MaxHP * 1.1f);

        int attackIncrease = Random.Range(1, 4); //randomize to add some RNG
        int defenseIncrease = Random.Range(1, 4);

        player.BaseAttack += attackIncrease;
        player.BaseDefense += defenseIncrease;
        Debug.Log($"Attack increased by {attackIncrease}");
        Debug.Log($"Defense increased by {defenseIncrease}");

        player.NextExp += 200 + Mathf.RoundToInt(player.level * 1.2f);
        player.level += 1;

        Debug.Log($"{player.name} has leveled up to level {player.level}! Calculating new stats...");
        GameManager.myGameManager.CalculateFinalStats(player);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerGrowth
{
    public PlayerData CurrentPlayer;

    public void GainExp(int value)
    {
        CurrentPlayer.CurrentExp += value;

        CheckLevelUp();
    }

    public void CheckLevelUp()
    {
        if (CurrentPlayer.CurrentExp >= CurrentPlayer.NextExp)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        CurrentPlayer.MaxHP = Mathf.RoundToInt(CurrentPlayer.MaxHP * 1.1f);
        CurrentPlayer.BaseAttack += 1;
        CurrentPlayer.BaseDefense += 1;

        CurrentPlayer.NextExp += 200 + Mathf.RoundToInt(CurrentPlayer.level * 1.2f);
        CurrentPlayer.level += 1;
    }

}

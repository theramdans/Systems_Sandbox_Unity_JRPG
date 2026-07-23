using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystems
{
    //manages battle damage calculations, enemy defeated state, exp reward from defeated enemies

    public void BattlePlayerAttacks(PlayerData player,int FinalAttack, EnemyData enemy)
    {
        int damage = Mathf.Max(0, FinalAttack - enemy.defense); //prevent damage from going negative
        enemy.CurrentHP = Mathf.Max(0, enemy.CurrentHP - damage); //prevent HP from going negative    

        CheckEnemyAliveState(enemy, player);
    }

    public void BattleEnemyAttacks(EnemyData enemy, PlayerData player, int FinalDefense)
    {
        int damage = Mathf.Max(0, enemy.attack - FinalDefense); //prevent damage from going negative
        player.CurrentHP = Mathf.Max(0, player.CurrentHP - damage) ; //prevent HP from going negative

        CheckPlayerAliveState(player);
    }

    public void CheckEnemyAliveState(EnemyData enemy, PlayerData player)
    {
        if (enemy.CurrentHP <= 0)
        {
            Debug.Log($"{enemy.name} defeated!");
            //enemy destruction goes here

            GameManager.MyGameManager.growth.GainExp(enemy.ExpReward, player);
        }
    }

    public void CheckPlayerAliveState(PlayerData player)
    {
        if (player.CurrentHP <= 0)
        {
            Debug.Log($"{player.name} has fallen :(");
            //player dies goes here
        }
    }
}

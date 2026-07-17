using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class EquipmentSystems
{
    public void EquipWeapon(PlayerData player, EquipmentData weapon)
    {
        player.EquippedWeapon = weapon;
    }

    public void EquipArmor(PlayerData player, EquipmentData armor)
    {
        player.EquippedArmor = armor;
    }

    public int CalculateFinalAttack(PlayerData player)
    {
        return (player.BaseAttack + player.EquippedWeapon.AttackBoost + player.EquippedArmor.AttackBoost);
    }

    public int CalculateFinalDefense(PlayerData player)
    {
        return (player.BaseDefense + player.EquippedWeapon.DefenseBoost + player.EquippedArmor.DefenseBoost);
    }
}

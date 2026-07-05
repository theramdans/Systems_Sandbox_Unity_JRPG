using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Weapon,
    Armor,
}

[System.Serializable]

public class EquipmentData
{
    public string EquipmentName;
    public EquipmentType Type;

    public int AttackBoost;
    public int DefenseBoost;
}

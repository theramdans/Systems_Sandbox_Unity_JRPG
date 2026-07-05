using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerData CurrentPlayer;
    [SerializeField] private PlayerGrowth Growth;
    [SerializeField] private EquipmentSystems EquipmentSystem;

    public Button expButton;

    private void Awake()
    {
        expButton.onClick.AddListener(AddExp);
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentPlayer = new PlayerData();
        CurrentPlayer.name = "Cloud";
        CurrentPlayer.CurrentExp = 0;
        CurrentPlayer.NextExp = 200;

        CurrentPlayer.level = 1;
        CurrentPlayer.MaxHP = 100;
        CurrentPlayer.CurrentHP = CurrentPlayer.MaxHP;
        CurrentPlayer.BaseAttack = 5;
        CurrentPlayer.BaseDefense = 5;

        Growth = new PlayerGrowth();
        Growth.player = CurrentPlayer;

        EquipmentData busterSword = new EquipmentData()
        {
            EquipmentName = "Buster Sword",
            Type = EquipmentType.Weapon,
            AttackBoost = 10,
            DefenseBoost = 1,
        };

        EquipmentData ironBangle = new EquipmentData()
        {
            EquipmentName = "Iron Bangle",
            Type = EquipmentType.Armor,
            AttackBoost = 1,
            DefenseBoost = 10
        };

        EquipmentSystem.EquipWeapon(CurrentPlayer, busterSword);
        EquipmentSystem.EquipArmor(CurrentPlayer, ironBangle);

        int finalAttack = EquipmentSystem.CalculateFinalAttack(CurrentPlayer);
        int finalDefense = EquipmentSystem.CalculateFinalDefense(CurrentPlayer);

        Debug.Log($"base attack = {CurrentPlayer.BaseAttack}");
        Debug.Log($"base defense = {CurrentPlayer.BaseDefense}");
        Debug.Log($"attack boost from {CurrentPlayer.EquippedWeapon.EquipmentName} = {CurrentPlayer.EquippedWeapon.AttackBoost}");
        Debug.Log($"defense boost from {CurrentPlayer.EquippedArmor.EquipmentName} = {CurrentPlayer.EquippedArmor.DefenseBoost}");
        Debug.Log($"final calculated attack = {finalAttack}");
        Debug.Log($"final calculated defense = {finalDefense}");

    }

    public void AddExp()
    {
        Growth.GainExp(50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

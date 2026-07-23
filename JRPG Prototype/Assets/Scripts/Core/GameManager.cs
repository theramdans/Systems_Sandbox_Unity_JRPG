using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager MyGameManager;

    [SerializeField] private PlayerData CurrentPlayer; //use List<Players> for multiple party members in the future
    [SerializeField] private List<EnemyData> enemies; //for now, use single enemy

    [SerializeField] private EquipmentSystems EquipmentSystem;
    [SerializeField] public PlayerGrowth growth;

    public Button expButton;

    private void Awake()
    {
        if (MyGameManager == null)
        {
            MyGameManager = this;
        }

        else
        {
            Destroy(gameObject);
        }
        Debug.Log(MyGameManager);

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

        //Growth = new PlayerGrowth();

        EquipmentData BusterSword = new EquipmentData()
        {
            EquipmentName = "Buster Sword",
            Type = EquipmentType.Weapon,
            AttackBoost = 10,
            DefenseBoost = 1,
        };

        EquipmentData IronBangle = new EquipmentData()
        {
            EquipmentName = "Iron Bangle",
            Type = EquipmentType.Armor,
            AttackBoost = 1,
            DefenseBoost = 10
        };

        EquipmentSystem.EquipWeapon(CurrentPlayer, BusterSword);
        EquipmentSystem.EquipArmor(CurrentPlayer, IronBangle);

        CalculateFinalStats(CurrentPlayer);
    }

    public void CalculateFinalStats(PlayerData player)
    {
        int FinalAttack = EquipmentSystem.CalculateFinalAttack(player);
        int FinalDefense = EquipmentSystem.CalculateFinalDefense(player);

        Debug.Log($"Base attack = {player.BaseAttack}");
        Debug.Log($"Base defense = {player.BaseDefense}");
        Debug.Log($"Attack boost from {player.EquippedWeapon.EquipmentName} = {player.EquippedWeapon.AttackBoost}");
        Debug.Log($"Attack boost from {player.EquippedArmor.EquipmentName} = {player.EquippedArmor.AttackBoost}");
        Debug.Log($"Defense boost from {player.EquippedArmor.EquipmentName} = {player.EquippedArmor.DefenseBoost}");
        Debug.Log($"Defense boost from {player.EquippedWeapon.EquipmentName} = {player.EquippedWeapon.DefenseBoost}");
        Debug.Log($"Final calculated attack = {FinalAttack}");
        Debug.Log($"Final calculated defense = {FinalDefense}");
    }

    public void AddExp()
    {
        growth.GainExp(50, CurrentPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager myGameManager;

    [SerializeField] private PlayerData CurrentPlayer; //use List<Players> for multiple party members in the future
    [SerializeField] private List<EnemyData> enemies; //for now, use single enemy

    [SerializeField] private EquipmentSystems EquipmentSystem;
    [SerializeField] public PlayerGrowth Growth;

    public Button expButton;

    private void Awake()
    {
        if (myGameManager == null)
        {
            myGameManager = this;
        }

        else
        {
            Destroy(gameObject);
        }
        Debug.Log(myGameManager);

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

        CalculateFinalStats(CurrentPlayer);
    }

    public void CalculateFinalStats(PlayerData player)
    {
        int finalAttack = EquipmentSystem.CalculateFinalAttack(player);
        int finalDefense = EquipmentSystem.CalculateFinalDefense(player);

        Debug.Log($"Base attack = {player.BaseAttack}");
        Debug.Log($"Base defense = {player.BaseDefense}");
        Debug.Log($"Attack boost from {player.EquippedWeapon.EquipmentName} = {player.EquippedWeapon.AttackBoost}");
        Debug.Log($"Attack boost from {player.EquippedArmor.EquipmentName} = {player.EquippedArmor.AttackBoost}");
        Debug.Log($"Defense boost from {player.EquippedArmor.EquipmentName} = {player.EquippedArmor.DefenseBoost}");
        Debug.Log($"Defense boost from {player.EquippedWeapon.EquipmentName} = {player.EquippedWeapon.DefenseBoost}");
        Debug.Log($"Final calculated attack = {finalAttack}");
        Debug.Log($"Final calculated defense = {finalDefense}");
    }

    public void AddExp()
    {
        Growth.GainExp(50, CurrentPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

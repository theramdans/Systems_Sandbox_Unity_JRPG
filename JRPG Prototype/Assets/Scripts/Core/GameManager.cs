using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerData CurrentPlayer;
    [SerializeField] private PlayerGrowth Growth;

    public Button expButton;

    private void Awake()
    {
        expButton.onClick.AddListener(AddExp);
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentPlayer = new PlayerData();
        CurrentPlayer.name = "Mey";
        CurrentPlayer.CurrentExp = 0;
        CurrentPlayer.NextExp = 200;

        CurrentPlayer.level = 1;
        CurrentPlayer.MaxHP = 100;
        CurrentPlayer.BaseAttack = 5;
        CurrentPlayer.BaseDefense = 5;

        Growth = new PlayerGrowth();
        Growth.player = CurrentPlayer;
        //NEXT
        //Create EquipmentData objects
        //Assign those objects to player
        //Call calculate final stats function in EquipmentSytems
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

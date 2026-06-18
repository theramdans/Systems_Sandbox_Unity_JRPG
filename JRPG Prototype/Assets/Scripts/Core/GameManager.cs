using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CharacterData Player;
    [SerializeField] private CharacterGrowth Growth;

    public Button expButton;

    private void Awake()
    {
        expButton.onClick.AddListener(AddExp);
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = new CharacterData();
        Player.name = "Mey";
        Player.currentExp = 0;
        Player.nextExp = 200;

        Player.level = 1;
        Player.maxHP = 100;
        Player.attack = 5;
        Player.defense = 5;

        Growth = new CharacterGrowth();
        Growth.Character = Player;
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

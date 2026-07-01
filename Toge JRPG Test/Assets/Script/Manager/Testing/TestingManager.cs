using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Timeline.DirectorControlPlayable;

public class TestingManager : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;

    InputAction fillPlayer, fillBoss, emptyBoss, emptyPlayer, refresh;

    [Header("Unit")]
    [SerializeField] List<PlayerActive> playerActives = new List<PlayerActive>();
    [SerializeField] List<EnemyActive> enemyActives = new List<EnemyActive>();

    void Start()
    {
        fillPlayer = playerInput.actions.FindAction("FillPlayerHp");
        fillBoss = playerInput.actions.FindAction("FillBossHp");
        emptyBoss = playerInput.actions.FindAction("EmptyBossHp");
        emptyPlayer = playerInput.actions.FindAction("EmptyPlayerHp");
        refresh = playerInput.actions.FindAction("RefreshTest");

        GetList();
    }

    void FillPlayerHP()
    {
        if (fillPlayer.triggered)
        {
            foreach (PlayerActive player in playerActives)
            {
                player.Health = player.MaxHealth;
            }
        }
    }

    void FillBossHP()
    {
        if (fillBoss.triggered)
        {
            foreach (EnemyActive enemy in enemyActives)
            {
                enemy.Health = enemy.MaxHealth;
            }
        }
    }

    void EmptyPlayerHP()
    {
        if (emptyPlayer.triggered)
        {
            foreach (PlayerActive player in playerActives)
            {
                player.Health = 1;
            }
        }
    }

    void EmptyBossHP()
    {
        if (emptyBoss.triggered)
        {
            foreach (EnemyActive enemy in enemyActives)
            {
                enemy.Health = 1;
            }
        }
    }

    void RefreshComponent()
    {
        if (refresh.triggered)
        {
            playerActives.Clear();
            enemyActives.Clear();

            GetList();
        }
    }

    void GetList()
    {
        PlayerActive[] players = FindObjectsByType<PlayerActive>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
        foreach (PlayerActive player in players)
        {
            playerActives.Add(player);
        }

        EnemyActive[] enemies = FindObjectsByType<EnemyActive>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
        foreach (EnemyActive enemy in enemies)
        {
            enemyActives.Add(enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RefreshComponent();
        FillPlayerHP();
        FillBossHP();
        EmptyBossHP();
        EmptyPlayerHP();
    }
}

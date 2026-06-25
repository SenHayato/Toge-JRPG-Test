using UnityEngine;

public enum GameState
{
    Exploration, Battle, Dialog, Cutscene
}

public class GameManager : MonoBehaviour
{
    public GameState gameState;

    [Header("Battle Manager")]
    [SerializeField] BattleManager battleManager;
}

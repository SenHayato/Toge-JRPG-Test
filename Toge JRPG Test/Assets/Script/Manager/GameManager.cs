using UnityEngine;

public enum GameState
{
    Exploration, Battle, Dialog, Cutscene
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState gameState;

    [Header("Game Component")]
    [SerializeField] Transform mainCamera;
    [SerializeField] Transform playerPosition;

    [Header("Battle Manager")]
    [SerializeField] BattleManager battleManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        mainCamera = Camera.main.transform;
        playerPosition = FindFirstObjectByType<PlayerActive>().transform;
    }

    public void ChangeToExploration()
    {
        if (gameState != GameState.Exploration)
        {
            gameState = GameState.Exploration;
        }
    }

    public void ChangeToDialogue()
    {
        if (gameState != GameState.Dialog)
        {
            gameState = GameState.Dialog;
        }
    }

    public void ChangeToBattle()
    {
        if (gameState != GameState.Battle)
        {
            gameState = GameState.Battle;
        }
    }

    public void ChangeToCutscene()
    {
        if (gameState != GameState.Cutscene)
        {
            gameState = GameState.Cutscene;
        }
    }

    public void CameraChild()
    {
        mainCamera.SetParent(playerPosition);
        mainCamera.SetLocalPositionAndRotation(new(0f,-0f,-2.11f), Quaternion.identity);
    }
}

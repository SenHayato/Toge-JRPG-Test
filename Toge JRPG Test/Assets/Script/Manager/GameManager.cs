using Fungus;
using UnityEngine;

public enum GameState
{
    Exploration, Battle, Dialog, Cutscene
}

public class GameManager : Singleton<GameManager>
{
    public GameState gameState;

    [Header("Game Component")]
    [SerializeField] Transform mainCamera;
    [SerializeField] Transform playerPosition;
    public bool testing;

    [Header("Intro Flowchart")]
    [SerializeField] Flowchart introFlow;

    //[Header("Battle Manager")]
    //[SerializeField] BattleManager battleManager;

    //[Header("HUD Manager")]
    //[SerializeField] HudManager hudManager;

    private void Start()
    {
        //mainCamera = Camera.main.transform;
        playerPosition = FindFirstObjectByType<PlayerActive>().transform;
        PauseManager.Instance.PauseDisable();
        introFlow.ExecuteBlock("Intro");
        //CameraChild(); //Masih coba untuk test, kalau flow tidak terganggu gak usah dihapus
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
            CameraUnChild();
        }
    }

    public void TestingEnable()
    {
        testing = true;
        Debug.Log("Kebal");
    }

    public void TestingDisable()
    {
        testing = false;
        Debug.Log("No Kebal");
    }

    //Bisa digunakan untuk peralihan ke gameplay
    public void CameraChild()
    {
        mainCamera.SetParent(playerPosition);
        mainCamera.SetLocalPositionAndRotation(new(0f,-0f,-2.11f), Quaternion.identity);
    }

    //Bisa digunakan untuk cutscene
    public void CameraChildNoReset()
    {
        mainCamera.SetParent(playerPosition);
        //mainCamera.SetLocalPositionAndRotation(new(0f,-0f,-2.11f), Quaternion.identity);
    }

    public void CameraUnChild()
    {
        mainCamera.SetParent(null);
    }

    //testing
    public void TestPlayerPosition()
    {
        Debug.Log("Posisi Player di " + playerPosition.position.ToString());
    }
}

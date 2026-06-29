using Fungus;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameState gameState;

    [Header("Game Component")]
    [SerializeField] Transform mainCamera;
    [SerializeField] Transform playerPosition;
    public bool testing;

    [Header("Intro Flowchart")]
    [SerializeField] Flowchart introFlow;

    //all Flowcharts
    [SerializeField] Flowchart[] flowcharts;

    //[Header("Battle Manager")]
    //[SerializeField] BattleManager battleManager;

    //[Header("HUD Manager")]
    //[SerializeField] HudManager hudManager;

    private void Start()
    {
        //mainCamera = Camera.main.transform;
        ResetFungusFlow();
        playerPosition = FindFirstObjectByType<PlayerActive>().transform;
        PauseManager.Instance.PauseDisable();
        //StartCoroutine(StartFlow());
        introFlow.ExecuteBlock("Intro");
        //CameraChild(); //Masih coba untuk test, kalau flow tidak terganggu gak usah dihapus
    }

    IEnumerator StartFlow()
    {
        yield return null;
        introFlow.ExecuteBlock("Intro");
    }

    public void ResetFungusFlow()
    {
        foreach(Flowchart chart in flowcharts)
        {
            chart.StopAllBlocks();
            chart.StopAllCoroutines();
            chart.ResetFlowchart(true, true);
        }
    }

    public void ChangeToExploration()
    {
        if (gameState != GameState.Exploration)
        {
            gameState = GameState.Exploration;
            HudManager.Instance.ExplorationHudSetUp();
        }
    }

    public void ChangeToDialogue()
    {
        if (gameState != GameState.Dialog)
        {
            gameState = GameState.Dialog;
            HudManager.Instance.HideAllHud();
        }
    }

    public void ChangeToBattle()
    {
        if (gameState != GameState.Battle)
        {
            gameState = GameState.Battle;
            HudManager.Instance.BattleHudSetUp();
        }
    }

    public void ChangeToCutscene()
    {
        if (gameState != GameState.Cutscene)
        {
            gameState = GameState.Cutscene;
            HudManager.Instance.HideAllHud();
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

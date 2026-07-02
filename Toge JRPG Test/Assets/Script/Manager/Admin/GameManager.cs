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
    [SerializeField] PlayerActive playerActive;
    public bool testing;

    [Header("Intro Flowchart")]
    [SerializeField] Flowchart introFlow;
    [SerializeField] Flowchart[] flowcharts;

    private void Start()
    {
        Application.targetFrameRate = 60;
        ResetFungusFlow();
        AudioManager.Instance.PlaySound(SoundType.Wind, true);
        playerActive = FindFirstObjectByType<PlayerActive>();
        playerPosition = playerActive.transform;
        PauseManager.Instance.PauseDisable();
        //StartCoroutine(StartFlow());
        //introFlow.ExecuteBlock("Intro"); //nanti idupin lagi
        //CameraChild(); //Masih coba untuk test, kalau flow tidak terganggu gak usah dihapus
    }

    //IEnumerator StartFlow()
    //{
    //    yield return null;
    //    introFlow.ExecuteBlock("Intro");
    //}

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
            AudioManager.Instance.PlaySound(SoundType.Wind, true);
            AudioManager.Instance.StopMusic(MusicType.Game);
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
            AudioManager.Instance.PlaySound(SoundType.Wind, false);
            AudioManager.Instance.PlayMusic(MusicType.Game);
            HudManager.Instance.BattleHudSetUp();
            BattleManager.Instance.StartBattle();
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

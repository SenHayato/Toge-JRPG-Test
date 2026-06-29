using Fungus;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : Singleton<PauseManager>
{
    [SerializeField] GameObject pauseMenu;
    public bool isPaused;
    [SerializeField] string MainMenuScene;

    //flowchart
    [SerializeField] Flowchart[] Flowcharts;

    private void Start()
    {
        Flowcharts = FindObjectsByType<Flowchart>(FindObjectsSortMode.None);
    }

    public void PauseEnable()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PauseDisable()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    //Pause Button

    public void ContinueButton()
    {
        PauseDisable();
    }

    public void RestartButton()
    {
        StopFlowcharts();
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().name));
    }

    void StopFlowcharts()
    {
        foreach(Flowchart chart in Flowcharts)
        {
            chart.StopAllBlocks();
        }
    }

    public void BackToMenuButton()
    {
        StopFlowcharts();
        StartCoroutine(LoadScene(MainMenuScene));
    }

    IEnumerator LoadScene(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            yield return null;
        }
    }
}

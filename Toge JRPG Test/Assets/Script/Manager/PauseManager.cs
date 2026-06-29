using Fungus;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : Singleton<PauseManager>
{
    [SerializeField] GameObject pauseMenu;
    public bool isPaused;
    [SerializeField] string MainMenuScene;

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
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().name));
    }

    public void BackToMenuButton()
    {
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

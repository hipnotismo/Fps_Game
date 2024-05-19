using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControler : MonoBehaviour
{
    [SerializeField] public Image LoadingProgressBar;
    [SerializeField] private int mainMenuBuildIndex = 0;
    [SerializeField] private int levelBuildIndex = 1;
    [SerializeField] private int fakeLoadingTime = 2;

    private void Update()
    {
        if (LoadingProgressBar != null)
        {
            LoadingProgressBar.fillAmount = LoadingControler.Get().loadingProgress;
        }
    }
    public void StartGameplay(GameObject Screen)
    {
        LoadingProgressBar.fillAmount = 0;
        ActivateScreen(Screen);
        LoadingControler.Get().LoadScene(levelBuildIndex, fakeLoadingTime);
    }

    public void BackToMenu(GameObject Screen)
    {
        DeactivateScreen(Screen);
    }

    public void LoadLevel(string SceneName)
    {
        SceneManager.LoadSceneAsync(SceneName);
    }

    private void ActivateScreen(GameObject Screen) 
    {
        Screen.SetActive(true);
    }

    private void DeactivateScreen(GameObject Screen)
    {
        Screen.SetActive(false);
    }
}

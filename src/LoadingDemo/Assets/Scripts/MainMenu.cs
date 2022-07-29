using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string _gameSceneName;
    [SerializeField]
    private GameObject _loadingPanel;
    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private GameObject _touchToContinueText;

    public void OnPlayButtonClicked() => StartCoroutine(LoadGameScene());

    private IEnumerator LoadGameScene()
    {
        DontDestroyOnLoad(transform.root);
        _loadingPanel.SetActive(true);
        Time.timeScale = 0;

        yield return WaitForLoading(SceneManager.LoadSceneAsync(_gameSceneName));
        yield return WaitForTouch();

        Time.timeScale = 1;
        GameFlow gameFlow = FindObjectOfType<GameFlow>();
        gameFlow.StartGame();
        Destroy(transform.root.gameObject);
    }

    private IEnumerator WaitForLoading(AsyncOperation task)
    {
        while (!task.isDone)
        {
            _slider.value = task.progress;
            yield return null;
        }
    }

    private IEnumerator WaitForTouch()
    {
        _touchToContinueText.SetActive(true);
        while (!Input.GetKeyDown(KeyCode.Mouse0))
        {
            yield return null;
        };
    }
}

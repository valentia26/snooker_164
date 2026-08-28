using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [SerializeField]
    private TMP_Text notiText;

    [SerializeField]
    private GameObject restartButton;

    [SerializeField]
    private GameObject exitButton;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ShowHideRestartButton(false);
        ShowHideExitButton(false);
    }

    public void ShowNotiText(string s)
    {
        if (notiText != null)
            notiText.text = s;
    }

    public void ShowHideRestartButton(bool flag)
    {
        if (restartButton != null)
            restartButton.SetActive(flag);
    }

    public void ShowHideExitButton(bool flag)
    {
        if (exitButton != null)
            exitButton.SetActive(flag);
    }

   
    public void ShowGameOverUI(string message)
    {
        ShowNotiText(message);
        ShowHideRestartButton(true);
        ShowHideExitButton(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
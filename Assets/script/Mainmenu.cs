using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour
{

    [SerializeField]
    private GameObject adjustPanel;

    [SerializeField]
    private Slider volumeSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.instance.PlayBGM(0);

        volumeSlider.value = AudioManager.instance.LoadCurrentMasterVolume();

      
        volumeSlider.onValueChanged.AddListener(AudioManager.instance.AdjustMasterVolume);
    }

    public void StartNewGame()
    {
        Setting.fromSave = false;
        SceneManager.LoadScene("Load");
    }

    public void LoadSaveGame()
    {
        Setting.fromSave = true;
        SceneManager.LoadScene("Load");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowHideAdjustPanel(bool flag)
    {
        adjustPanel.SetActive(flag);
    }

    public void SetVolume(float volume)
    {
        AudioManager.instance.AdjustMasterVolume(volume);
    }
}
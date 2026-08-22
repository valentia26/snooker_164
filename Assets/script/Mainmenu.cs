using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour
{
    [SerializeField]
    private Slider volumeSlider;;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.instance.PlayBGM(0);

        volumeSlider.value = AudioManager.instance
    }

    // Update is called once per frame
    public void StartGame()
    {
        SceneManager.LoadScene("Scene01");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

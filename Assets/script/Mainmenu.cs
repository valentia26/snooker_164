using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour
{
    [SerializeField]
    private Slider volumeSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.instance.PlayBGM(0);

        // ตั้งค่า slider ให้ตรงกับ volume ที่เคยบันทึกไว้
        volumeSlider.value = AudioManager.instance.LoadCurrentMasterVolume();

        // เมื่อลาก slider ให้ปรับ volume ผ่าน AudioMixer
        volumeSlider.onValueChanged.AddListener(AudioManager.instance.AdjustMasterVolume);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Scene01");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
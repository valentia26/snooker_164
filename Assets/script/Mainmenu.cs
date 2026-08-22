using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

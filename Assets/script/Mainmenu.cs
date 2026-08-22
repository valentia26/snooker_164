using UnityEngine;

public class Mainmenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void StartGame()
    {
        Scenemanager.LoadScene("Scene01");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

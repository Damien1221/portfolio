using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string _nextScene;
    public GameObject panel;

    public void OnClick()
    {
        SceneManager.LoadScene(_nextScene);
    }

    public void OnQuitGame()
    {
        Debug.Log("Quit Game");

        Application.Quit();
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }

}

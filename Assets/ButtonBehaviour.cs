using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    void Start()
    {

    }
    public void Load(String name)
    {
        SceneManager.LoadScene(name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void HidePassword(GameObject gameObject)
    {
        if (gameObject != null)
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }

    public void ShowThreat(GameObject gameObject)
    {
        Debug.Log("Code no sucky wucky");
        gameObject.SetActive(true);
    }
}

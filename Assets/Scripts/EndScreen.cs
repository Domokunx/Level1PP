using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public Button restartButton;
    public Button backButton;
    // Start is called before the first frame update
    void Start()
    {
        restartButton.onClick.AddListener(Win);
        backButton.onClick.AddListener(BackToMainMenu);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Win()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

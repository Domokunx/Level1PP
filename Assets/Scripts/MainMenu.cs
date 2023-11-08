using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button stageButton;
    public Button endlessButton;
    // Start is called before the first frame update
    void Start()
    {
        endlessButton.onClick.AddListener(startEndless);
        stageButton.onClick.AddListener(startStage);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void startStage()
    {
        SceneManager.LoadScene("Level 1");
    }

    void startEndless()
    {
        SceneManager.LoadScene("Endless");
    }
}

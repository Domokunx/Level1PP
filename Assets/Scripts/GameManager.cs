using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerManager playerManager;
    public GameObject gameOverScreen;
    public static bool gameOver;
    void Start()
    {
        gameOver = false;
        gameOverScreen.SetActive(false);
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerManager.currentHealth <= 0)
        { 
            gameOver = true;
            Dead();
        }
    }
    
    public void Dead() 
    {
        gameOverScreen.SetActive(true);
    }
}

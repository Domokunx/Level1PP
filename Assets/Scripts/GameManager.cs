using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerManager playerManager;
    public GameObject gameOverScreen;
    bool inWinArea;
    void Start()
    {
        gameOverScreen.SetActive(false);
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerManager.currentHealth <= 0)
        {
            Dead();
        }
        print(inWinArea + "" + playerManager.drunkLevel);
        if (inWinArea && playerManager.drunkLevel > 0 )
        {
            Win();
        }
    }
    void Win()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Dead() 
    {
        gameOverScreen.SetActive(true);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Win")
        {
            inWinArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Win")
        {
            inWinArea = false;
        }
    }
}

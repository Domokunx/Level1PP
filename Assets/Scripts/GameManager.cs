using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerManager playerManager;
    bool inWinArea;
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
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
        if(inWinArea && playerManager.drunkLevel > 100)
        {
            Win();
        }
    }
    void Win()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Win")
        {
            inWinArea = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Win")
        {
            inWinArea = false;
        }
    }
}

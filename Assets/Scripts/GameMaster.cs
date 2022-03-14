using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public int currentLevel = 1;

    public float playerPoints = 0;
    public float maxLevelPoints;
    public float playerLives = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(playerLives <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }

        if (playerPoints >= maxLevelPoints)
        {
            if(currentLevel == 1)
            {
                SceneManager.LoadScene("Level2");
            }
            else if (currentLevel == 2)
            {
                SceneManager.LoadScene("Level3");
            }
            else if (currentLevel == 3)
            {
                SceneManager.LoadScene("Level4");
            }
            else if (currentLevel == 4)
            {
                SceneManager.LoadScene("Level5");
            }
            else if(currentLevel == 5)
            {
                SceneManager.LoadScene("WinScene");
            }
            playerPoints = 0;
            currentLevel = currentLevel + 1;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene("OpenScene");
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            SceneManager.LoadScene("LoseScene");
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene("WinScene");
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            playerPoints = maxLevelPoints;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScript : MonoBehaviour
{
    public GameObject BananaEatenTextObj;
    public GameObject BananaSavedTextObj;
    private int BananaCount;
    void Start()
    {
        BananaCount = GameObject.FindGameObjectsWithTag("Banana").Length;
    }

    void Update()
    {
        int saved = 0;
        int eaten = 0;

        if (GameObject.FindGameObjectsWithTag("Banana").Length == 0)
        {
            eaten = BananaEatenTextObj.GetComponent<BananaEatenText>().getScore();
            saved = BananaSavedTextObj.GetComponent<BananaSavedText>().getScore();

            if (eaten > saved)
            {
                SceneManager.LoadScene("Lose");
            }
            else
            {
                SceneManager.LoadScene("Win");
            }
        }
    }
}

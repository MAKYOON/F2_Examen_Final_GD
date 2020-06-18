using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelScript : MonoBehaviour
{
    Timer timer;
    PlayerFievre playerController;
    [SerializeField]
    GameObject wonGameObject;
    [SerializeField]
    GameObject lostGameObject;
    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        timer.Elapsed += SelectUIToDisplay;
        playerController = GameObject.Find("PlayerFievre").GetComponent<PlayerFievre>();
    }
    
    void SelectUIToDisplay()
    {
        if (playerController.collectedCytokines >= 20)
        {
            wonGameObject.SetActive(true);
        }
        else
        {
            lostGameObject.SetActive(true);
        }

        StartCoroutine((EndLevel()));
    }

    IEnumerator EndLevel()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2.0f);
        SceneManager.LoadScene("MainMenu");
    }
}

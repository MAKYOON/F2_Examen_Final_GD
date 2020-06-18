using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelInfection : MonoBehaviour
{
    Timer timer;
    [SerializeField]
    GameObject wonGameObject;

    static PhagocyteScript phagocyte;
    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        timer.Elapsed += DisplayWin;
    }

    void DisplayWin()
    {
        StartCoroutine(EndLevel());
    }

    IEnumerator EndLevel()
    {
        wonGameObject.SetActive(true);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2.0f);
        SceneManager.LoadScene("MainMenu");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelAntiviral : MonoBehaviour
{
    Timer timer;
    [SerializeField]
    GameObject wonGameObject;

    PhagocyteScript phagocyte;
    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        timer.Elapsed += DisplayWin;
    }

    void DisplayWin()
    {
        this.gameObject.SetActive(true);
        wonGameObject.SetActive(true);
        Time.timeScale = 0;
    }
}

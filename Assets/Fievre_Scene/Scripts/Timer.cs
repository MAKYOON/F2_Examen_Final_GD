using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float countdownTimer;
    [SerializeField]
    TextMeshProUGUI timerText;

    public delegate void TimeElapsed();

    public event TimeElapsed Elapsed;

    bool eventFired = false;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = countdownTimer;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            int seconds = (int)timer;
            timerText.text = seconds.ToString();
        }
        else if (eventFired == false)
        {
            Elapsed?.Invoke();
            eventFired = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LostScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndLevel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EndLevel()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2.0f);
        SceneManager.LoadScene("MainMenu");
    }
}

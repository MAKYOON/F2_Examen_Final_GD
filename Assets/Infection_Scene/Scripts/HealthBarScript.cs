using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarScript : MonoBehaviour
{
    Image image;
    PlayerInfection playerInfection;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        playerInfection = GameObject.Find("PlayerInfection").GetComponent<PlayerInfection>();
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = (float)playerInfection.Health/100;
    }
}

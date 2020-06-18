using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField]
    GameObject mainMenuDisplay;
    [SerializeField]
    GameObject infectionDisplay;
    [SerializeField]
    GameObject reactionDisplay;
    [SerializeField]
    GameObject traitementDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleButtons()
    {
        mainMenuDisplay.SetActive(false);
        switch (EventSystem.current.currentSelectedGameObject.name)
        {
            case "ButtonInfection":
                infectionDisplay.SetActive(true);
                break;
            case "ButtonReactionImmunitaire":
                reactionDisplay.SetActive(true);
                break;
            case "ButtonTraitement":
                traitementDisplay.SetActive(true);
                break;
            default :
                EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.SetActive(false);
                mainMenuDisplay.SetActive(true);
                break;
        }
    }

    public void LoadScene()
    {
        switch (EventSystem.current.currentSelectedGameObject.name)
        {
            case "InfectionLevelButton":
                SceneManager.LoadScene("Infection");
                break;
            case "FievreLevelButton":
                SceneManager.LoadScene("Fievre");
                break;
            case "TraitementLevelButton":
                SceneManager.LoadScene("Antiviral");
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coronavirus : MonoBehaviour
{
    float speed = 5.0f;
    bool antiviral;
    [SerializeField]
    GameObject loseGameObject;
    PlayerAntiviral player;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Antiviral")
        {
            antiviral = true;
            player = GameObject.Find("PlayerAntiviral").GetComponent<PlayerAntiviral>();
        }
        else
            antiviral = false;
    }

    void Update()
    {
        if (antiviral)
        {
            transform.Translate( speed * Time.deltaTime * Vector2.left , Space.World);
        }
        else
        {
            if (transform.position.x >= 0)
                transform.Translate(speed * Time.deltaTime * Vector2.right, Space.World);
            else
                transform.Translate(speed * Time.deltaTime * Vector2.left, Space.World);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Border")
            Destroy(this.gameObject);
        else if (other.gameObject.tag == "Barrier")
        {
            Destroy(gameObject);
            player.virusPassed++;
            CheckStatus();
        }
    }

    void CheckStatus()
    {
        if (player.virusPassed >= 3)
        {
            player.lose.SetActive(true);
        }
    }

}

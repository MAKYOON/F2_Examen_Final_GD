using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfection : PlayerClass
{
    Vector2 direction;
    Rigidbody2D rb;
    float speed = 6.0f;
    int maxHealth = 100;
    int currentHealth;
    [SerializeField]
    GameObject lostGameObject;
    

    BaseState currentState;
    public readonly LosingHealthState LosingHealthState = new LosingHealthState();
    public readonly IncreasingLifeState IncreasingLifeState = new IncreasingLifeState();

    public int Health
    {
        get
        {
            return currentHealth;
        }

        set
        {
            currentHealth = value;
        }
    }
      
    public void TransitionToState(BaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        currentState.OnTriggerEnter2D(this);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        currentState.OnTriggerExit2D(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        TransitionToState(LosingHealthState);
    }

    void FixedUpdate()
    {
        Move(direction, rb, speed);
    }

    void Update()
    {
        currentState.Update(this);
    }

    void RemoveHealth()
    {
        if (currentHealth > 0)
            currentHealth -= 4;
    }

    void AddHealth()
    {
        if (currentHealth < 100)
            currentHealth += 6;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            lostGameObject.SetActive(true);
    }
}

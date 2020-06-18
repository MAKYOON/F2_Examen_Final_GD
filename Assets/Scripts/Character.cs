using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    Animator animator;
    [SerializeField] GameObject atchoum;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
	    if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Sneezing");
            StartCoroutine(Atchoum());
        }	
	}

    IEnumerator Atchoum()
    {
        yield return new WaitForSeconds(1);
        atchoum.SetActive(true);
        yield return new WaitForSeconds(1);
        atchoum.SetActive(false);
    }
}

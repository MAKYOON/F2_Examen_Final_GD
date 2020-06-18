using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    [SerializeField]
    TMP_Text text;
    public Dialogue dialogue;
    [SerializeField]
    Text dialogueButton;
    [SerializeField]
    GameObject dialogueDisplay;
    [SerializeField]
    TextMeshProUGUI timer;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject healthBar;
    [SerializeField]
    GameObject cellToInfect;

    void Start()
    {
        sentences = new Queue<string>();
        StartDialogue(dialogue);
        Time.timeScale = 0;
    }

    public void StartDialogue (Dialogue dialogue)
    {
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            dialogueDisplay.SetActive(false);
            Time.timeScale = 1;
            timer.enabled = true;
            if (player != null)
                player.SetActive(true);
            if (healthBar != null)
                healthBar.SetActive(true);
            if (cellToInfect != null)
                cellToInfect.SetActive(true);
            return;
        }

        if (sentences.Count == 1)
        {
            dialogueButton.text = "Terminer";
        }
        string sentenceToDisplay = sentences.Dequeue();
        text.text = sentenceToDisplay;

    }
}

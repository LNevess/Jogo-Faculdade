using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;  // Refer�ncia ao Text UI element
    public Dialog dialog;    // Refer�ncia ao di�logo que ser� exibido
    public string sceneName;

    private Queue<string> sentences;  // Fila de senten�as do di�logo atual

    void Start()
    {
        sentences = new Queue<string>();
        StartDialog(dialog);
    }

    public void StartDialog(Dialog dialog)
    {
        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
    }

    void EndDialog()
    {
        SceneManager.LoadScene(sceneName);
    }

    void Update()
    {
        // Verifica se a tecla espa�o ou o bot�o esquerdo do mouse foi pressionado para avan�ar o di�logo
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            DisplayNextSentence();
        }
    }
}

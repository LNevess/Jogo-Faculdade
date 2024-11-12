using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;  // Referência ao Text UI element
    public Dialog dialog;    // Referência ao diálogo que será exibido
    public string sceneName;

    public bool isStarted;

    private Queue<string> sentences;  // Fila de sentenças do diálogo atual


    ObjectActivator activator;
	public bool NoGoFase;
	void Start()
    {
        activator = FindFirstObjectByType<ObjectActivator>();
        sentences = new Queue<string>();
        //StartDialog(dialog);
    }

    public void StartDialog(Dialog dialog)
    {
        sentences.Clear();
        isStarted = true;

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (PauseMenu.isPaused)
        {
            return;
        }

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
        if (!NoGoFase)
        {
            SceneManager.LoadScene(sceneName);
            print("bu");
        }
        else 
        {
            activator.interactObject.SetActive(false);
        }
    }

    void Update()
    {
        // Verifica se a tecla espaço ou o botão esquerdo do mouse foi pressionado para avançar o diálogo
        if (!isStarted)
        {
            return;
        }

        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            DisplayNextSentence();
        }
    }
}

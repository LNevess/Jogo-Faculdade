using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [System.Serializable]
    public class DialogueLine
    {
        public string text;
        public AudioClip audioClip;
    }

    public TMP_Text dialogueText;
    public GameObject dialoguePanel; // Painel do diálogo a ser ativado
    public AudioSource audioSource;
    public float textSpeed = 0.05f;
    public float startDelay = 2.0f; // Tempo de espera antes de iniciar o diálogo
    public DialogueLine[] dialogueLines;
    public GameObject nextPhaseScreen; // Referência à tela com botão para próxima fase
    public XpBarAnimator1 xpAnimator;

    private int currentLineIndex = 0;
    private bool isTyping = false;

    void Start()
    {
        Debug.Log("Script iniciado");
        //dialoguePanel.SetActive(false); // Garante que o painel de diálogo está desativado no início
        //nextPhaseScreen.SetActive(false); // Garante que a tela não apareça no início
        StartCoroutine(StartDialogueWithDelay());
    }

    IEnumerator StartDialogueWithDelay()
    {
        Debug.Log("Iniciando diálogo...");
        yield return new WaitForSeconds(startDelay); // Aguarda o tempo especificado antes de iniciar o diálogo
        //dialoguePanel.SetActive(true); // Ativa o painel de diálogo
        StartCoroutine(DisplayDialogue());
    }

    IEnumerator DisplayDialogue()
    {
        while (currentLineIndex < dialogueLines.Length)
        {
            yield return StartCoroutine(TypeText(dialogueLines[currentLineIndex].text));
            audioSource.clip = dialogueLines[currentLineIndex].audioClip;
            audioSource.Play();

            yield return new WaitUntil(() => !audioSource.isPlaying);

            currentLineIndex++;
        }

        ShowNextPhaseScreen(); // Chama a tela ao final do diálogo
    }

    IEnumerator TypeText(string text)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in text)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }

    void ShowNextPhaseScreen()
    {
        nextPhaseScreen.SetActive(true); // Ativa a tela com botão para a próxima fase
        xpAnimator.StartXPAnimation(0.5f); // Exemplo: preenche a barra até 75%
    }
}

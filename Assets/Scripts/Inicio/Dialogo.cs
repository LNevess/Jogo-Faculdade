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
    public GameObject dialoguePanel; // Painel do di�logo a ser ativado
    public AudioSource audioSource;
    public float textSpeed = 0.05f;
    public float startDelay = 2.0f; // Tempo de espera antes de iniciar o di�logo
    public DialogueLine[] dialogueLines;
    public GameObject nextPhaseScreen; // Refer�ncia � tela com bot�o para pr�xima fase
    public XpBarAnimator1 xpAnimator;

    private int currentLineIndex = 0;
    private bool isTyping = false;

    void Start()
    {
        Debug.Log("Script iniciado");
        //dialoguePanel.SetActive(false); // Garante que o painel de di�logo est� desativado no in�cio
        //nextPhaseScreen.SetActive(false); // Garante que a tela n�o apare�a no in�cio
        StartCoroutine(StartDialogueWithDelay());
    }

    IEnumerator StartDialogueWithDelay()
    {
        Debug.Log("Iniciando di�logo...");
        yield return new WaitForSeconds(startDelay); // Aguarda o tempo especificado antes de iniciar o di�logo
        //dialoguePanel.SetActive(true); // Ativa o painel de di�logo
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

        ShowNextPhaseScreen(); // Chama a tela ao final do di�logo
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
        nextPhaseScreen.SetActive(true); // Ativa a tela com bot�o para a pr�xima fase
        xpAnimator.StartXPAnimation(0.5f); // Exemplo: preenche a barra at� 75%
    }
}

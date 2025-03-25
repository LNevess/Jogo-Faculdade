using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class XpBarAnimator1 : MonoBehaviour
{
    [Header("Barra de Experiência")]
    public Image xpBar;
    public float animationDuration = 1.5f;
    private float targetXP;

    [Header("Objeto Central")]
    public Image centralObject;
    public Color targetColor;

    [Header("Texto de Nível")]
    public TMP_Text levelText;
    public string newLevelText;

    [Header("Partícula")]
    public ParticleSystem levelUpEffect;

    private float initialXP;
    private Color initialColor;
    private bool isAnimating = false;
    private float elapsedTime = 0f;

    void Start()
    {
        if (xpBar != null)
            initialXP = xpBar.fillAmount;
    }

    public void StartXPAnimation(float newTargetXP)
    {
        if (!isAnimating)
        {
            initialXP = xpBar.fillAmount;
            targetXP = newTargetXP;
            elapsedTime = 0f;
            isAnimating = true;

            // Redefinir a cor inicial para garantir que a animação sempre inicie corretamente
            if (centralObject != null)
                initialColor = centralObject.color;
        }
    }

    void Update()
    {
        if (isAnimating)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / animationDuration;

            if (xpBar != null)
                xpBar.fillAmount = Mathf.Lerp(initialXP, targetXP, progress);

            if (centralObject != null)
                centralObject.color = Color.Lerp(initialColor, targetColor, progress);

            if (elapsedTime >= animationDuration)
            {
                FinishAnimation();
            }
        }
    }

    private void FinishAnimation()
    {
        if (xpBar != null)
            xpBar.fillAmount = targetXP;

        if (centralObject != null)
            centralObject.color = targetColor; // Garante que a cor final seja aplicada apenas uma vez

        if (levelText != null)
            levelText.text = newLevelText;

        if (levelUpEffect != null)
            levelUpEffect.Play();

        isAnimating = false;
    }
}
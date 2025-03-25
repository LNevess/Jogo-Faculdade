using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnSpace : MonoBehaviour
{
    
    public GameObject vitoria;
    public XpBarAnimator1 xpAnimator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Verifica se a tecla SPACE foi pressionada
        {
            vitoria.SetActive(true);
            xpAnimator.StartXPAnimation(1f); // Exemplo: preenche a barra até 75%
        }
    }
}

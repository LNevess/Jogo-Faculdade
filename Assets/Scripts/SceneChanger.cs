using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Nome da cena que voc� quer carregar
    public string sceneName;

    // M�todo que muda de cena
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

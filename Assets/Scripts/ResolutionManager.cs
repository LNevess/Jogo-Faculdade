using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    private int targetWidth = 1920;
    private int targetHeight = 1080;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        SetResolution();
    }

    private void SetResolution()
    {
        // Calcula a proporção da tela desejada e da tela atual
        float targetAspect = (float)targetWidth / targetHeight;
        float windowAspect = (float)Screen.width / Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        // Ajusta a viewport da câmera principal para manter a proporção
        if (scaleHeight < 1.0f)
        {
            Rect rect = mainCamera.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            mainCamera.rect = rect;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = mainCamera.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            mainCamera.rect = rect;
        }
    }

    void OnPreCull()
    {
        // Tarjas pretas acima e abaixo (letterbox)
        if (mainCamera.rect.height < 1.0f)
        {
            GL.Clear(true, true, Color.black);
        }
        // Tarjas pretas nas laterais (pillarbox)
        else if (mainCamera.rect.width < 1.0f)
        {
            GL.Clear(true, true, Color.black);
        }
    }
}

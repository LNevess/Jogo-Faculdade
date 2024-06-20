using UnityEngine;

public class SetResolution : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        // Define a resolução para 1920x1080
        Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);

        // Se desejar janela sem borda (windowed), use:
        // Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);

        // Se desejar tela cheia exclusiva, use:
        // Screen.SetResolution(1920, 1080, FullScreenMode.ExclusiveFullScreen);

        // Se desejar tela cheia maximizada, use:
        // Screen.SetResolution(1920, 1080, FullScreenMode.MaximizedWindow);
    }
}

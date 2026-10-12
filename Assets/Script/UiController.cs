using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class UiController : MonoBehaviour
{
    public GameObject gameOverImage;
    public GameObject uiMenu;
    public void GameOver()
    {
        gameOverImage.SetActive(true);
    }
}

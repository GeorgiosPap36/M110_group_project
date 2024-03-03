using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
        // If we are running in the Unity editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // If we are running in a standalone build of the game
        Application.Quit();
        #endif
    }
}

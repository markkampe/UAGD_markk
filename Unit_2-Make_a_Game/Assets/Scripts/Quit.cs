using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quitscript : MonoBehaviour
{

    public void exit()
    {
#if UNITY_EDITOR
        // Debug.Log("Game is stopping");
	UnityEditor.EditorApplication.isPlaying = false;
#else
        // Debug.Log("Game is exiting");
	Application.Quit();
#endif
    }
}

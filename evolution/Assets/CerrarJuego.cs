using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarJuego : MonoBehaviour
{
    // Método que será llamado cuando se haga clic en el botón
    public void ExitGame()
    {
        // Si estamos en el editor de Unity, parar la ejecución
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Si estamos en una build, cerrar la aplicación
        Application.Quit();
#endif
    }
}

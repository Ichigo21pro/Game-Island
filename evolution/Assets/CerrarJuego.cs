using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarJuego : MonoBehaviour
{
    // M�todo que ser� llamado cuando se haga clic en el bot�n
    public void ExitGame()
    {
        // Si estamos en el editor de Unity, parar la ejecuci�n
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Si estamos en una build, cerrar la aplicaci�n
        Application.Quit();
#endif
    }
}

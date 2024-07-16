using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeEsceneOnClick : MonoBehaviour
{
    // Nombre de la escena a la que se desea cambiar
    public string sceneName;

    void Update()
    {
        // Detecta si se ha pulsado cualquier tecla o botón del ratón
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            ChangeScene();
        }
    }

    // Método para cambiar de escena
    void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

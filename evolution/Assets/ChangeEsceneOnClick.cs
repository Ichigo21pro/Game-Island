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
        // Detecta si se ha pulsado cualquier tecla o bot�n del rat�n
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            ChangeScene();
        }
    }

    // M�todo para cambiar de escena
    void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

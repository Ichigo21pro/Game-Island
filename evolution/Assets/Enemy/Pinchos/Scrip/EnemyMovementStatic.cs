using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

   
 void MoveTo()
    {

    }
    IEnumerator Moving(Vector3 start, Vector3 end, float duration)
    {
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            // Incrementar el tiempo transcurrido
            elapsedTime += Time.deltaTime;

            // Calcular el porcentaje del tiempo transcurrido
            float t = elapsedTime / duration;

            // Interpolar la posición entre el inicio y el final
            transform.position = Vector3.Lerp(start, end, t);

            // Esperar al siguiente frame
            yield return null;
        }

        // Asegurarse de que la posición final sea exactamente la posición final deseada
        transform.position = end;
    }

}


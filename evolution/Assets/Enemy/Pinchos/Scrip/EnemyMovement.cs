using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementStatic : MonoBehaviour
{
    bool isStopGame = false;
    private void OnEnable()
    {
        DetectMove.StartMoving += MoveTo;
        AnimationController.StopAll += GameStop;
    }

    private void OnDisable()
    {
        DetectMove.StartMoving -= MoveTo;
        AnimationController.StopAll -= GameStop;
    }

    void MoveTo(Vector3 End, GameObject Object, float time)
    {

        if (Object == gameObject)
        {
            StartCoroutine(Moving(transform.position, End, time));
        }
        

    }

    void GameStop(bool stop) { 
        isStopGame = stop;
    }
    IEnumerator Moving(Vector3 start, Vector3 end, float duration)
    {

        float elapsedTime = 0;

        while (elapsedTime < duration&&!isStopGame)
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


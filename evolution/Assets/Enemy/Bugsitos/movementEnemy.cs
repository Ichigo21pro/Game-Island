using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementEnemy : MonoBehaviour
{
    public string tagDelJugador = "Player";
    public float velocidad = 0.5f;
    public string tagDeLaCamara = "MainCamera"; // Cambia esto al tag correcto de tu cámara
    public SpriteRenderer sprite;

    private Transform player;
    private bool enContactoConCamara = false;
    private void Update()
    {
        if (enContactoConCamara) { MoverEnX(); }


    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el collider tiene el tag de la cámara
        if (other.CompareTag(tagDeLaCamara))
        {
            enContactoConCamara = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Verifica si el collider tiene el tag de la cámara
        if (other.CompareTag(tagDeLaCamara))
        {
            enContactoConCamara = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }



    private void MoverEnX()
    {
        // Encuentra el objeto con el tag "Player" al inicio
        player = GameObject.FindGameObjectWithTag(tagDelJugador).transform;

        if (player == null)
        {
            Debug.LogError("No se encontró un objeto con el tag 'Player'");
        }

        // Verifica si se encontró el objeto "Player"
        if (player != null)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
           
            if (direction.x < 0)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
            // Mueve el objeto en la dirección calculada
            transform.Translate(direction * velocidad * Time.deltaTime);
        }
    }

}

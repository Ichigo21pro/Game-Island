using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMove : MonoBehaviour
{
    [SerializeField] private GameObject ObjectToMove;
    [SerializeField] float time = 0.5f;
    [SerializeField] private Vector3 GoHere;
    public bool Autodestroy = false;
    public static event Action<Vector3, GameObject, float> StartMoving;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
          
            StartMoving?.Invoke(GoHere, ObjectToMove, time);
            if(Autodestroy)
            {
                Destroy(gameObject);
            }
        }
    }
}

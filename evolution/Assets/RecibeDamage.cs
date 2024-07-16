using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecibeDamage : MonoBehaviour
{
   

   
    public string stage;
    public AudioClip damage;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            GameManger.Instance.SendDeath(false);
            SoundManager.Instance.PlayASoundOneTime(damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            GameManger.Instance.SendDeath(false);
            SoundManager.Instance.PlayASoundOneTime(damage);
        }
    }

    public void ResetStage()
    {
        GameManger.Instance.ResetStage(stage);
    } 
}

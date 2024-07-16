using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTime : MonoBehaviour
{
    public static event Action<int> AddTimeFinished;
    public int HowMuchAdd = 2;
    public AudioClip clip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AddTimeFinished?.Invoke(HowMuchAdd);
            SoundManager.Instance.PlayASoundButWhitChange(clip);
            Destroy(gameObject);
        }
    }

}

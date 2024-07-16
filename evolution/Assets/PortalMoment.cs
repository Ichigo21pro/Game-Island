using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalMoment : MonoBehaviour
{
    public string Stage;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("EndLevel");
        }
    }
    public void ChangeStage()
    {
        GameManger.Instance.ResetStage(Stage);
    }
}

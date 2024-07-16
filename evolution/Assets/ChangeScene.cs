using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void PlayGame()
    {
        GameManger.Instance.ResetDeath();
        GameManger.Instance.ResetStage("Lvl1");
    }
}

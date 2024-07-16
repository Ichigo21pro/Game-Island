using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public static GameManger Instance;
    public static event Action<bool> DamageChanged;
    [SerializeField] int deaths = 0;

    private void Awake()
    {
        if(Instance != null && Instance!=this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
  
    public void Adddeath()
    {
        deaths++;
    }

    public void ResetDeath()
    {
        deaths = 0;
    }

    public int GetDeaths()
    {
        return deaths;
    }

    public void SendDeath(bool de)
    {
        DamageChanged?.Invoke(false);
    }

    public void ResetStage(string stage)
    {
        SceneManager.LoadScene(stage);
    }

}

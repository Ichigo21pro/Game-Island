using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddDeaths : MonoBehaviour
{
   
    [SerializeField] TextMeshProUGUI textMeshPro;

    private void OnEnable()
    {
        GameManger.DamageChanged += AddDeath;
    }

    private void OnDisable()
    {
        GameManger.DamageChanged -= AddDeath;
    }

    private void Start()
    {
        textMeshPro.text = GameManger.Instance.GetDeaths().ToString();
    }

    void AddDeath (bool isDeath)
    {
        GameManger.Instance.Adddeath();
        textMeshPro.text= GameManger.Instance.GetDeaths().ToString();
    }
}

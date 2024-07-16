using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Temporizador : MonoBehaviour
{

    private TimeSpan currentTime;
    [SerializeField] TimeSpan TimeLeft;// Tiempo actual del temporizador
    private bool isTimerRunning;  // Indica si el temporizador está corriendo
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    private void OnEnable()
    {
        AddTime.AddTimeFinished += Addtime;
    }
    private void OnDisable()
    {
        AddTime.AddTimeFinished -= Addtime;
    }
    void Start()
    {
        currentTime = TimeSpan.FromSeconds(0);
        TimeLeft = TimeSpan.FromSeconds(60);
        isTimerRunning = true;

        // Iniciar la corrutina para actualizar el temporizador
        StartCoroutine(UpdateTimer());
    }
   void Update()
    {
        if (TimeLeft.Seconds >= 0 && TimeLeft.Minutes >= 0 && TimeLeft.Hours >= 0)
        {
            textMeshProUGUI.text = FormatTime(TimeLeft);
        }
    }

    IEnumerator UpdateTimer()
    {
        while (isTimerRunning)
        {
            currentTime = currentTime.Add(TimeSpan.FromSeconds(1));
            TimeLeft = TimeLeft.Subtract(TimeSpan.FromSeconds(1));
           
            
           
            if (TimeLeft.Seconds <= 0&&TimeLeft.Minutes<=0&&TimeLeft.Hours<=0)
            {
                isTimerRunning=false;
                GameManger.Instance.SendDeath(false);


            }
            yield return new WaitForSeconds(1f);
        }
       
    }

    
    string FormatTime(TimeSpan time)
    {
        return string.Format("{0:00}:{1:00}:{2:00}", time.Hours, time.Minutes, time.Seconds);
    }

    void OnDestroy()
    {
        // Asegurarse de detener la corrutina cuando se destruye el objeto
        isTimerRunning = false;
    }

    void Addtime(int addingtime) {
        TimeLeft=TimeLeft.Add(TimeSpan.FromSeconds(addingtime));
        
    }
}

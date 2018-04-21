using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerRegressivo : MonoBehaviour
{
    private Text timer;
    private bool fimDeTempo = false;
    private bool timerPausado = false;
    private float tempoRestante;
    
    public bool FimDeTempo
    {
        get
        {
            return fimDeTempo;
        }
    }

    private void Start()
    {
        timer = GetComponent<Text>();
    }

    private void Update()
    {
        if (tempoRestante != 0 && timerPausado == false)
        {
            tempoRestante -= Time.deltaTime;

            if (tempoRestante <= 0)
            {
                tempoRestante = 0;
                fimDeTempo = true;
            }
            AtualizaTempo();
        }
    }
    
    private void AtualizaTempo()
    {
        timer.text = "Tempo: " + (tempoRestante.ToString("f") + "\"").Replace('.', '\'');
    }

    public void IniciarTimer(float tempoRestante)
    {
        this.tempoRestante = tempoRestante;
    }

    public void PausarTimer()
    {
        timerPausado = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    [SerializeField] private GameMaster gm;
    [SerializeField] private Text tempo_txt;
    private float tempoDaFase;

    private void Start()
    {
        TempoDeFase();
    }

    private void Update()
    {
        IniciarCronometro();

        ImprimeTempo();
        
    }

    private void TempoDeFase()
    {
        this.tempoDaFase = gm.TempoParaCompletarFase();
    }

    public float IniciarCronometro()
    {
        tempoDaFase -= Time.deltaTime;

        if (tempoDaFase <= 0)
        {
            tempoDaFase = 0;            
        }
        return tempoDaFase;
    }

    public void ImprimeTempo()
    {
        tempo_txt.text = "Tempo: " + (IniciarCronometro().ToString("f") + "\"").Replace('.', '\'');
    }
}
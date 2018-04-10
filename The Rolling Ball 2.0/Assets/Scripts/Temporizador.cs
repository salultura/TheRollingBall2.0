using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    private float tempoRestante;

    public void DefineTempoDaFase(float tempoDefase)
    {
        tempoRestante = tempoDefase;
    }

    public bool Cronometro()
    {
        tempoRestante -= Time.deltaTime;
        bool tempoEsgotado = false;
        if (tempoRestante <= 0)
        {
            tempoRestante = 0;
            tempoEsgotado = true;
        }
        return tempoEsgotado;
    }

    public void AtualizaTempo(bool faseCompleta, Text tempo_txt)
    {
        if (!faseCompleta)
        {
            tempo_txt.text = "Tempo: " + (tempoRestante.ToString("f") + "\"").Replace('.', '\'');
        }
    }
}
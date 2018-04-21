using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GerenciadorDoJogo : MonoBehaviour
{
    //Componentes externos
    [SerializeField] private Placar placar;
    [SerializeField] private TimerRegressivo timer;
    [SerializeField] private GameObject faseCompleta_txt;
    [SerializeField] private GameObject tempoEsgotado_txt;

    //Propriedades do Placar
    private int pontuacao = 0;
    private int pontuacaoFaseAnterior = 0;

    //Propriedades da Fase
    private int qtdItensColetaveis;
    private float dificuldade = 3f;
    private bool faseCompleta = false;

    private void Awake()
    {
                
    }

    void Start()
    {
        qtdItensColetaveis = GameObject.Find("Itens").transform.childCount;
        DespausarJogo();
        timer.IniciarTimer(DefinirTempoDeFase());
    }

    private void Update()
    {
        CompletarLevel();
    }

    private float DefinirTempoDeFase()
    {
        return qtdItensColetaveis * dificuldade;
    }

    public void ColetarItem(int pontos)
    {
        pontuacao += pontos;
        qtdItensColetaveis--;
        placar.Atualizar(pontuacao);
    }

    private void CompletarLevel()
    {
        if (timer.FimDeTempo)
        {
            PausarJogo();
            tempoEsgotado_txt.SetActive(true);
        }

        if (qtdItensColetaveis == 0)
        {
            faseCompleta = true;
            faseCompleta_txt.SetActive(true);
            timer.PausarTimer();
            Time.timeScale = .8f;
            pontuacaoFaseAnterior = pontuacao;
            StartCoroutine(ProximaFase());
        }
    }

    private void PausarJogo()
    {
        Time.timeScale = 0f;
    }

    private void DespausarJogo()
    {
        Time.timeScale = 1;
    }

    public void ReiniciarFase()
    {
        pontuacao = pontuacaoFaseAnterior;
        int cenaAtual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(cenaAtual);
    }

    public IEnumerator ProximaFase()
    {
        yield return new WaitForSeconds(3);
        int cenaAtual = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(cenaAtual);
    }
}

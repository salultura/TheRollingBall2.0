using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private Text placar_txt;
    [SerializeField] private Text tempo_txt;
    [SerializeField] private GameObject faseCompleta_txt;
    [SerializeField] private GameObject tempoEsgotado_txt;

    private bool fimDoTempo = false;
    private static int placar = 0;
    private static int placarLevelAnterior = 0;
    private int ponto = 10;
    private int qtdItensColetaveis;
    private float tempoRestante;
    private float dificuldade = 3f;
    private bool faseCompleta = false;


    private void Awake()
    {
        qtdItensColetaveis = GameObject.FindGameObjectsWithTag("Coletavel").Length;
    }

    void Start()
    {
        IniciarJogo();
    }

    private void Update()
    {
        IniciarTimer();
        CompletarLevel();
    }

    private void DefinirTempoDeFase()
    {
        tempoRestante = qtdItensColetaveis * dificuldade;
    }

    public void ColetarItem()
    {
        placar += ponto;
        qtdItensColetaveis--;
        AtualizarPlacar();
    }

    private void AtualizarPlacar()
    {
        placar_txt.text = "Placar: " + placar;
    }

    private void CompletarLevel()
    {
        if (fimDoTempo)
        {
            PausarJogo();
            tempoEsgotado_txt.SetActive(true);
        }

        if (qtdItensColetaveis == 0)
        {
            faseCompleta = true;
            faseCompleta_txt.SetActive(true);
            Time.timeScale = .8f;
            placarLevelAnterior = placar;
            //Salvando o placar
            //PlayerPrefs.SetInt("Placar", placar);
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

    private void IniciarTimer()
    {
        tempoRestante -= Time.deltaTime;

        if (tempoRestante <= 0)
        {
            tempoRestante = 0;
            fimDoTempo = true;

        }
        AtualizaTempo();
    }

    private void AtualizaTempo()
    {
        if (!faseCompleta)
        {
            tempo_txt.text = "Tempo: " + (tempoRestante.ToString("f") + "\"").Replace('.', '\'');
        }

    }

    private void IniciarJogo()
    {
        //ResetarPlacar();
        AtualizarPlacar();
        DefinirTempoDeFase();
        Time.timeScale = 1;
    }

    public void ReiniciarFase()
    {
        placar = placarLevelAnterior;
        int cenaAtual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(cenaAtual);
        //Recuperando o placar da fasde anterior
        //placar = PlayerPrefs.GetInt("Placar");
    }

    public IEnumerator ProximaFase()
    {
        yield return new WaitForSeconds(3);
        int cenaAtual = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(cenaAtual);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{
    [SerializeField] private int pontos = 10;
    private GerenciadorDoJogo gerenciador;

    private void Start()
    {
        gerenciador = GameObject.Find("Gerenciador do Jogo").GetComponent<GerenciadorDoJogo>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            gerenciador.ColetarItem(pontos);
        }
    }
}

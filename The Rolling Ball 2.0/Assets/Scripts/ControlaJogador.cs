using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour
{
    public float velocidade = 8;
    private Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MovimentacaoDoPersonagem();
    }

    private void MovimentacaoDoPersonagem()
    {
        float movimentoX = Input.GetAxis("Horizontal");
        float movimentoZ = Input.GetAxis("Vertical");
        Vector3 direcao = new Vector3(movimentoX, 0.0f, movimentoZ);

        rb.AddForce(direcao * velocidade);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    private Rigidbody rb;

    private float velocidade = 8;
    private float forcaPulo = 4;
    private int vidas = 3;
        
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Pular();
        }
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

    private void Pular()
    {
        rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
    }
}

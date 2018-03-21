using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaCamera : MonoBehaviour {
    public GameObject jogador;
    private Vector3 distanciaParaJogador;
	// Use this for initialization
	void Start () {
        distanciaParaJogador = gameObject.transform.position - jogador.transform.position;
	}

    void LateUpdate()
    {
        gameObject.transform.position = distanciaParaJogador + jogador.transform.position;    
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Placar : MonoBehaviour {

    private Text placar;

	// Use this for initialization
	void Start () {
        placar = GetComponent<Text>();
	}

    public void Atualizar(int placarAtual)
    {
        placar.text = "Placar: " + placarAtual;
    }
}


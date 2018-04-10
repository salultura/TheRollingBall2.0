using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacionador : MonoBehaviour {

    Vector3 rotacao;
	
	// Update is called once per frame
	void Update () {
        rotacao = new Vector3(15, 30, 45);

        transform.Rotate(rotacao * Time.deltaTime);
	}
}

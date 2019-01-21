using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuberiasGenerator : MonoBehaviour {
    [SerializeField] GameObject tuberiasPrefab;
    [SerializeField] float tiempo = 2.2f;
    GameObject gestorJuego;
	
	void Start () {
        gestorJuego = GameObject.Find("GestorJuego");
        InvokeRepeating("CrearTuberia", 0, tiempo);
        
    }

    private void CrearTuberia() {
        if (gestorJuego.GetComponent<GestorJuego>().GetJugando() == true) {
            Instantiate(tuberiasPrefab, transform);
        }
        
    }
       
}

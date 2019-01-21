using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestorJuego : MonoBehaviour {
    [SerializeField] Text textoPuntuacion;

    private  int puntos = 0;
    private  bool jugando;

    public int Puntos {
        get {
            return puntos;
        }

        set {
            puntos = value;
            textoPuntuacion.text = puntos.ToString();
        }
    }

    private void Start() {
        jugando = true;
    }

    public bool GetJugando() {
        return jugando;
    }

    
    public void FinalizarPartida() {
        jugando = false;
        Invoke("RecargarEscena", 2f);
    }
    private void RecargarEscena() {
       SceneManager.LoadScene(0);
                    
               
    }


    
}

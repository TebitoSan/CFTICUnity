using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrankyScript : MonoBehaviour {
    [SerializeField] private float force = 15f;
    [SerializeField] GameObject sangrePrefab;
    [SerializeField] AudioClip aleteo;
    [SerializeField] AudioClip golpe;
    [SerializeField] AudioClip puntuacion;
    [SerializeField] float velocidadRotacion = -5f;
    private Rigidbody rb; // declarando el atributo
    private AudioSource audioSource;
    private GameObject gestorJuego;

   
	void Start () {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        gestorJuego = GameObject.Find("GestorJuego");
	}
	
    
	void Update () {
        transform.rotation = Quaternion.Euler(new Vector3(rb.velocity.y * velocidadRotacion, 0, 0));
		
        if (Input.GetKeyDown(KeyCode.Space)) {
            Impulsar();

        }

	}

    void Impulsar() {
        
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        audioSource.PlayOneShot(aleteo);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Limite") == false) {
            gestorJuego.GetComponent<GestorJuego>().FinalizarPartida();
            GameObject sangre = Instantiate(sangrePrefab);
            sangre.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        int puntos = gestorJuego.GetComponent<GestorJuego>().Puntos;
        puntos++;
        gestorJuego.GetComponent<GestorJuego>().Puntos = puntos;
    }
}


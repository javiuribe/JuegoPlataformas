using UnityEngine;

public class EliminadorEnemigos : MonoBehaviour {
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Enemigo"){
            //Desactivacion: no se ve ni colisiona
            other.gameObject.SetActive(false);
            //Destruccion con retardo para evitar parar la UI
            Destroy(other.gameObject, 0.5f);
        }
    }
}

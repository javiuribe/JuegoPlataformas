using UnityEngine;

public class Ataque : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Enemigo"){
            other.gameObject.SetActive(false);
            Destroy(other.gameObject, 0.5f);
            //gameObject.SetActive(false);
            //Destroy(gameObject, 0.5f);
        }
    }
}

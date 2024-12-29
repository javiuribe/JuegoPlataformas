using UnityEngine;

public class Generador : MonoBehaviour
{
    public GameObject objeto;
    public float probabilidadAparicion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      GenerarObjetos();  
    }

    private void GenerarObjetos()
    {
        float random = Random.Range(0.0f, 100f);
        if (random < probabilidadAparicion){
            GameObject.Instantiate(objeto, transform.position, transform.rotation);
        }
    }
}

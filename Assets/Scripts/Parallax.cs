using System;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Renderer[] olas;
    public float[] velocidadesOlas;
    public GameObject[] fondos;
    public float[] velocidadesFondos;
    public float[] sizes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        MoverOlas();
        MoverFondos();
    }

    private void MoverFondos()
    {
        for (int i = 0; i < fondos.Length; i++)
        {
            if (Mathf.Abs(fondos[i].transform.localPosition.x) > sizes[i])
            {
                //Regresa al fondo a posicion inicial
                fondos[i].transform.localPosition = new Vector3(
                    0.0f, 
                    fondos[i].transform.position.y, 
                    fondos[i].transform.position.z);
            } else 
            {
                //Mover fondo
                float offset = Time.deltaTime * velocidadesFondos[i];
                fondos[i].transform.localPosition += new Vector3(offset, 0.0f);
            }
        }
    }

    private void MoverOlas()
    {
        for (int i = 0; i < olas.Length; i++)
        {
            float offset = Time.time * velocidadesOlas[i];
            olas[i].material.SetTextureOffset("_MainTex", new Vector2(offset, 0.0f));
        }

    }
}

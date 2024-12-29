using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI vidasTxt;
    public TextMeshProUGUI monedasTxt;
    public Personaje personaje;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vidasTxt.text = personaje.Vidas.ToString();
        monedasTxt.text = personaje.monedas.ToString();
    }
}

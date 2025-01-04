using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI vidasTxt;
    public TextMeshProUGUI monedasTxt;
    public Personaje personaje;
    public GameObject gameOverPn;
    public TextMeshProUGUI recordTxt;
    public TextMeshProUGUI monedasGameOverTxt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vidasTxt.text = personaje.Vidas.ToString();
        monedasTxt.text = personaje.monedas.ToString();
        if (personaje.Vidas <=0 && !gameOverPn.activeSelf){
            gameOverPn.SetActive(true);
            recordTxt.text = PlayerPrefs.GetInt("monedas").ToString();
            monedasGameOverTxt.text = personaje.monedas.ToString();
        }
    }

    public void Restart(){
        SceneManager.LoadScene("Juego");
    }
}

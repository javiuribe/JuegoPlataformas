using UnityEngine;

public class Personaje : MonoBehaviour
{
	private bool saltando;
	public int Vidas{get;set;}
	private bool atacando;
	private bool moviendoDerecha;
	private bool moviendoIzquierda;
	public int monedas{get;set;}
	public GameObject ataqueOriginal;
	public GameObject ataquePosicion;
	public Animator animator;
	public AudioClip sonidoSalto;
	public AudioClip sonidoAterrizaje;
	private AudioSource personajeAudioSource;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		Vidas = 3;
		personajeAudioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.LeftArrow) || moviendoIzquierda)
		{
			MoverIzquierda();
		}
		else if (Input.GetKey(KeyCode.RightArrow) || moviendoDerecha)
		{
			MoverDerecha();
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
        {
			Saltar();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Atacar();
        }
    }

	public void setMoverIzquierda(bool activar){
		moviendoIzquierda = activar;
	}

	public void setMoverDerecha(bool activar){
		moviendoDerecha = activar;
	}

	public void MoverIzquierda(){
		transform.Translate(new Vector3(-0.1f, 0.0f));
	}

	public void MoverDerecha(){
		transform.Translate(new Vector3(0.1f, 0.0f));
	}

    public void Atacar()
    {
		if (!atacando){
			GameObject.Instantiate(
							ataqueOriginal, ataquePosicion.transform.position,
							ataquePosicion.transform.rotation);
			Invoke("TerminarAtaque", 0.5f);
			atacando = true;
			animator.SetTrigger("Attack1");
		}
    }

    public void Saltar()
    {
		if (!saltando){
			animator.SetTrigger("Jump");
			animator.SetFloat("AirSpeedY", 1);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 450.0f));
			saltando = true;
			animator.SetBool("Grounded", false);
			Invoke("BajarVelocidadAire", 0.6f);
			personajeAudioSource.PlayOneShot(sonidoSalto);
		}
    }

    private void TerminarAtaque()
	{
		atacando = false;
	}

	private void BajarVelocidadAire(){
		animator.SetFloat("AirSpeedY", -1);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Item")
		{
			other.gameObject.SetActive(false);
			Destroy(other.gameObject, 0.2f);
			monedas++;
			Debug.Log("Monedas:" + monedas);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Suelo")
		{
			saltando = false;
			animator.SetBool("Grounded", true);
			personajeAudioSource.PlayOneShot(sonidoAterrizaje);
		}
		if (other.gameObject.tag == "Enemigo")
		{
			animator.SetTrigger("Hurt");
			other.gameObject.SetActive(false);
			Destroy(other.gameObject, 0.5f);
			Vidas--;
			Debug.Log("Vidas:" + Vidas);
			if (Vidas == 0)
			{
				Debug.Log("GAME OVER");
				gameObject.SetActive(false);
				animator.SetTrigger("Death");
				int recordMonedas = PlayerPrefs.GetInt("monedas", 0);
				if (monedas > recordMonedas)
				{
					PlayerPrefs.SetInt("monedas", monedas);
					Debug.Log("Record:"+monedas);
				}
			}
		}
	}
}

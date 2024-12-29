using UnityEngine;

public class Personaje : MonoBehaviour
{
	private bool saltando;
	public int Vidas{get;set;}
	private bool atacando;
	public int monedas{get;set;}
	public GameObject ataqueOriginal;
	public GameObject ataquePosicion;
	public Animator animator;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		Vidas = 3;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(new Vector3(-0.1f, 0.0f));
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(new Vector3(0.1f, 0.0f));
		}
		if (!saltando && Input.GetKeyDown(KeyCode.UpArrow))
		{
			animator.SetTrigger("Jump");
			animator.SetFloat("AirSpeedY", 1);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 500.0f));
			saltando = true;
			animator.SetBool("Grounded", false);
			Invoke("BajarVelocidadAire", 0.6f);
		}
		if (!atacando && Input.GetKeyDown(KeyCode.Space))
		{
			GameObject.Instantiate(
				ataqueOriginal, ataquePosicion.transform.position,
				ataquePosicion.transform.rotation);
			Invoke("TerminarAtaque", 0.5f);
			atacando = true;
			animator.SetTrigger("Attack1");
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
				//gameObject.SetActive(false);
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

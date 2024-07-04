using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using System.ComponentModel;

public class PlayerController : MonoBehaviour {

	public Image BarraVida;
	public AudioClip jumpSound;

	public float JumpForce = 5.0f;
	public float Speed = 2.0f;
	public float MaxJumpHeight = 4.0f;
	public GameObject Spada;
	public int maxHealth = 5;
	private int currentHealth;
	private float LastShoot;
    public float tiempoRestante = 3.0f; // Tiempo inicial en segundos
    public Text textTiempo;
	public Text textGameOver;
    public int score = 0; // Puntaje inicial del jugador
    public int pointsPerStar = 5; // Puntos obtenidos por cada estrella recogida
    public Text scoreText;

    private Rigidbody2D rigidbody2D;
	private Animator animator;
	private AudioSource audioSource;
	private float horizontal;
	private bool Grounded;

	// Use this for initialization
	void Start() {
		animator = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D>();
		currentHealth = maxHealth; 
		UpdateHealthBar();
        Time.timeScale = 1f;
    }

	// Update is called once per frame
	void Update() {
		horizontal = Input.GetAxis("Horizontal");
		if (horizontal < 0.0f)
			transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
		else if (horizontal > 0.0f)
			transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);



		animator.SetBool("Running", horizontal != 0.0f);



		// Check if player is grounded
		if (Physics2D.Raycast(transform.position, Vector2.down, 1.0f)) {
			Grounded = true;
		} else {
			Grounded = false;
		}



		// Jump if player is grounded and W key is pressed
		if (Input.GetKeyDown(KeyCode.W) && Grounded) {
			Jump();
		}



		// Handle attacking animation
		if (Input.GetKey(KeyCode.Space)) {
			if (Time.time > LastShoot + 1f) {
				Shoot();
				LastShoot = Time.time;
			}
		}

 



            // Actualizar el temporizador cada frame
            if (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
            textTiempo.text = "Tiempo: " + Mathf.FloorToInt(tiempoRestante).ToString() + " Segundos";
        }
        else
        {
            textTiempo.text = "¡Tiempo agotado!";
			// Aquí puedes agregar lógica adicional que quieres que suceda cuando el tiempo se acabe
			textGameOver.text = "Perdiste!";
			Time.timeScale = 0f;
			ReiniciarPartida();
			
            
            
        }


    }

    void ReiniciarPartida()
    {
        // Recarga la escena actual
        SceneManager.LoadScene("Juegos2D");
    }



    private void FixedUpdate() {

		rigidbody2D.velocity = new Vector2(horizontal * Speed, rigidbody2D.velocity.y);

		// Limit vertical speed to avoid excessive jumps
		if (rigidbody2D.velocity.y > MaxJumpHeight) {
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, MaxJumpHeight);
		}

	}



	private void Jump() {
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpForce);
		Camera.main.GetComponent<AudioSource>().PlayOneShot(jumpSound);
	}



	public void TakeDamage(int damage) {
		currentHealth -= damage;
		UpdateHealthBar(); // Actualizar la barra de vida
		if (currentHealth == 0) {
            // Handle player death
            textGameOver.text = "Perdiste!";
           // Time.timeScale = 0f;
			Debug.Log("Player died!");          
                ReiniciarPartida();           
            // Puedes agregar lógica adicional para manejar la muerte del jugador, como reiniciar la escena
        } else {
			Debug.Log("Player health: " + currentHealth);
            
        }

	}



	private void UpdateHealthBar() {
		BarraVida.fillAmount = (float)currentHealth / maxHealth; // Actualizar el fillAmount de la barra de vida
	}




	private void Shoot() {
		Vector2 direction;
		Quaternion rotation;

		if (transform.localScale.x < 0) {
			direction = Vector2.left;
			rotation = Quaternion.Euler(0, 0, 180);
		} else {
			direction = Vector2.right;
			rotation = Quaternion.Euler(0, 0, 0);
		}

		GameObject PlayerAtaque = Instantiate(Spada, transform.position + (Vector3)direction * 1f, rotation); // Cambié 0.1f a 1f para que salga al frente
		PlayerAtaque.GetComponent<Espada>().SetDirection(direction);
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Estrella"))
        {
            ConsumeEstrella(other.gameObject);
        }
    }

    void ConsumeEstrella(GameObject Estrella)
    {
        score += pointsPerStar; // Añade los puntos por recoger la estrella al puntaje total
        UpdateScoreText();
        // Aquí puedes agregar lógica para actualizar puntuaciones o efectos de sonido
        Debug.Log("Estrella consumida!");

        // Destruye el objeto estrella
        Destroy(Estrella);
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString(); // Actualiza el texto de UI con el nuevo puntaje
    }

}

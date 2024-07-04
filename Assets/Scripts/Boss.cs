using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

    public Image BarraVida;
    public GameObject Player;
	public GameObject spada;

	public int maxHealth = 20;

    private Rigidbody2D rigidbody2D;
    private int currentHealth;
	private float LastShoot;

	void Start() {
		//animator = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D>();
		currentHealth = maxHealth; 
		UpdateHealthBar();
        Time.timeScale = 1f;
    }

	private void Update()
	{

		Vector3 direction = Player.transform.position - transform.position;

		if (direction.x >= 0.0f)
			transform.localScale = new Vector3(-1.8659f, 1.8659f, 1.8659f);
		else
			transform.localScale = new Vector3(1.8659f, 1.8659f, 1.8659f);

		float distance = Mathf.Abs(Player.transform.position.x - transform.position.x);

		if (distance < 20.0f && Time.time > LastShoot + 5f)
		{
			Shoot();
			LastShoot = Time.time;
		}
	}

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthBar(); // Actualizar la barra de vida
        if (currentHealth <= 0)
        {
            // Handle player death
            Debug.Log("Player died!");
            // Puedes agregar lógica adicional para manejar la muerte del jugador, como reiniciar la escena
        }
        else
        {
            Debug.Log("Player health: " + currentHealth);
        }

    }

    private void Shoot()
	{
		Vector2 direction;
		Quaternion rotation;

		if (transform.localScale.x > 0)
		{
			direction = Vector2.left;
			rotation = Quaternion.Euler(0, -10, 270);
		}
		else
		{
			direction = Vector2.right;
			rotation = Quaternion.Euler(0, -10, 90);
		}

		GameObject espada1 = Instantiate(spada, transform.position + (Vector3)direction * 6f, rotation); // Cambié 0.1f a 0.5f para que salga al frente
		espada1.GetComponent<Espada>().SetDirection(direction);
		//UnityEngine.Debug.Log("Atacando...");
	}


    private void UpdateHealthBar()
    {
        BarraVida.fillAmount = (float)currentHealth / maxHealth; // Actualizar el fillAmount de la barra de vida
    }
}
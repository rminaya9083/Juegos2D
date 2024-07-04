using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour {


	public GameObject Player;
	public GameObject spada;

	public int maxHealth = 5;


	private int currentHealth;
	private float LastShoot;

	void Start() {
		//rigidbody2D = GetComponent<Rigidbody2D>();
		currentHealth = maxHealth; // Inicializar la vida actual del jugador
	}

	private void Update()
	{

		Vector3 direction = Player.transform.position - transform.position;

		if (direction.x >= 0.0f)
			transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
		else
			transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);

		float distance = Mathf.Abs(Player.transform.position.x - transform.position.x);

		if (distance < 20.0f && Time.time > LastShoot + 3f)
		{
			Shoot();
			LastShoot = Time.time;
		}
	}

	public void TakeDamage(int damage) {
		currentHealth -= damage;
		if (currentHealth <= 0) {
			// Handle player death
			Debug.Log("Enemy 1 died!");
			Destroy(gameObject);
			// Puedes agregar lógica adicional para manejar la muerte del jugador, como reiniciar la escena
		} else {
			Debug.Log("Enemy 1 health: " + currentHealth);
		}
	}

	private void Shoot()
	{
		Vector2 direction;
		Quaternion rotation;

		if (transform.localScale.x < 0)
		{
			direction = Vector2.left;
			rotation = Quaternion.Euler(0, 0, 270);
		}
		else
		{
			direction = Vector2.right;
			rotation = Quaternion.Euler(0, 0, 90);
		}

		GameObject espada1 = Instantiate(spada, transform.position + (Vector3)direction * 2f, rotation); // Cambié 0.1f a 0.5f para que salga al frente
		espada1.GetComponent<Espada>().SetDirection(direction);
		//UnityEngine.Debug.Log("Atacando...");
	}

}
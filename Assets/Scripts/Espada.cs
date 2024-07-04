using System.Collections;
using System.Collections;
using UnityEngine;

public class Espada : MonoBehaviour {

	public AudioClip Sound;


	public float speed;
	public int damage = 1;  // Daño que la espada inflige al jugador

	private Rigidbody2D Rigidbody2D;
	private Vector2 Direction;

	void Start() {
		Rigidbody2D = GetComponent<Rigidbody2D>();
		Camera.main.GetComponent<AudioSource> ().PlayOneShot(Sound);
	}

	private void FixedUpdate() {
		Rigidbody2D.velocity = Direction * speed;
	}

	public void SetDirection(Vector2 direction) {
		Direction = direction;
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag("Player")) {
			PlayerController player = collision.GetComponent<PlayerController>();
			if (player != null) {
				player.TakeDamage(damage);
				Destroy(gameObject); // Destruir la espada después de colisionar con el jugador
			}
		}
		if (collision.CompareTag("Enemy")) {
			Enemy enemy = collision.GetComponent<Enemy>();
			if (enemy != null) {
				enemy.TakeDamage(damage);
				Destroy(gameObject); // Destruir la espada después de colisionar con el jugador
			}
		}

		if (collision.CompareTag("Enemy1")) {
			Enemy2 enemy2 = collision.GetComponent<Enemy2>();
			if (enemy2 != null) {
				enemy2.TakeDamage(damage);
				Destroy(gameObject); // Destruir la espada después de colisionar con el jugador
			}
		}

        if (collision.CompareTag("Enemy2"))
        {
            Enemy3 enemy3 = collision.GetComponent<Enemy3>();
            if (enemy3 != null)
            {
                enemy3.TakeDamage(damage);
                Destroy(gameObject); // Destruir la espada después de colisionar con el jugador
            }
        }

        if (collision.CompareTag("Enemy3"))
        {
            Enemy4 enemy4 = collision.GetComponent<Enemy4>();
            if (enemy4 != null)
            {
                enemy4.TakeDamage(damage);
                Destroy(gameObject); // Destruir la espada después de colisionar con el jugador
            }
        }

        if (collision.CompareTag("Boss"))
        {
            Boss boss = collision.GetComponent<Boss>();
            if (boss != null)
            {
                boss.TakeDamage(damage);
                Destroy(gameObject); // Destruir la espada después de colisionar con el jugador
            }
        }
    }
}

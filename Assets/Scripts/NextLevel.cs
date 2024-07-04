using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
	public string nextLevelName; // Nombre del siguiente nivel
	public AudioClip touchSound; // Sonido al tocar el objeto activador

	private AudioSource audioSource;

	void Start()
	{
		audioSource = gameObject.AddComponent<AudioSource>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			PlaySoundAndLoadNextLevel();
		}
	}

	void PlaySoundAndLoadNextLevel()
	{
		// Reproducir el sonido
		audioSource.PlayOneShot(touchSound);
		// Esperar a que el sonido termine antes de cargar el siguiente nivel
		StartCoroutine(WaitForSoundAndLoad());
	}

	IEnumerator WaitForSoundAndLoad()
	{
		// Esperar a que el sonido termine
		yield return new WaitForSeconds(touchSound.length);
		// Cargar el siguiente nivel
		SceneManager.LoadScene(nextLevelName);
	}
}
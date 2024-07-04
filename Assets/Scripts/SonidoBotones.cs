using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonidoBotones : MonoBehaviour
{
	public AudioClip clickSound; // Sonido del clic del botón

	private Button button;

	void Start()
	{
		button = GetComponent<Button>();
		if (button != null)
		{
			button.onClick.AddListener(PlaySound);
		}
	}

	void PlaySound()
	{
		Camera.main.GetComponent<AudioSource>().PlayOneShot(clickSound);
	}
}

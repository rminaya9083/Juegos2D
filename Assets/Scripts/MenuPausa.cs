using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour {

	[SerializeField] private GameObject BotonPausa;
	[SerializeField] private GameObject menuPausa;

   /* void Start()
    {
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
        BotonPausa.SetActive(true);
    }*/
    
	public void Pausa()
	{
		Time.timeScale = 0f;
		BotonPausa.SetActive (false);
		menuPausa.SetActive (true);
	}

	public void Reanudar()
	{
		Time.timeScale = 1f;
		BotonPausa.SetActive (true);
		menuPausa.SetActive (false);
	}

	public void Reiniciar()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void Cerrar()
	{
		//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 1);
		SceneManager.LoadScene("MenuInicio");
	}



}

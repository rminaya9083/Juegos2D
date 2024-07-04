using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour {

	public void Jugar()
	{
		//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		SceneManager.LoadScene("Juegos2D");

    }

    public void Nivel2()
    {
        //SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
        SceneManager.LoadScene("Nivel2");

    }

    public void Nivel3()
    {
        //SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
        SceneManager.LoadScene("Nivel3");

    }

    public void BOSS()
    {
        //SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
        SceneManager.LoadScene("BOSS");

    }

    public void Salir()
	{
		Debug.Log ("Salir...");
		Application.Quit ();
	}

}

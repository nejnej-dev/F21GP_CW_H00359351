using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScene : MonoBehaviour
{
	public void Menu()
	{
		SceneManager.LoadScene("Menu");
	}

	public void Quit()
	{
		Application.Quit();
	}
}

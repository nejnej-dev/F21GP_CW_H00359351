using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BananaSavedText : MonoBehaviour
{
	private int savedValue = 0;
	public Text text = null;
	public AudioSource win;

	private void Start()
	{
		DrawScore();
	}

	public void AddScore()
	{
		win.Play();
		savedValue += 1;
		DrawScore();
	}

	private void DrawScore()
	{
		text.text = "Banana saved: " + savedValue.ToString();
	}

	public int getScore()
	{
		return savedValue;
	}
}

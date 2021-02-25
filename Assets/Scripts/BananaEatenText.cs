using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BananaEatenText : MonoBehaviour
{
	private int eatenValue = 0;
	public Text text = null;
	private void Start()
	{
		DrawScore();
	}

	public void AddScore()
	{
		eatenValue += 1;
		DrawScore();
	}

	private void DrawScore()
	{
		text.text = "Banana eaten: " + eatenValue.ToString();
	}

	public int getScore()
    {
		return eatenValue;
    }
}

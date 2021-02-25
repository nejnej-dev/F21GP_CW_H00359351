using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BananaSavedText : MonoBehaviour
{
	private int savedValue = 0;
	public Text text = null;
	private void Start()
	{
		DrawScore();
	}

	public void AddScore()
	{
		savedValue += 1;
		DrawScore();
	}

	private void DrawScore()
	{
		text.text = "Banana saved: " + savedValue.ToString();
	}
}

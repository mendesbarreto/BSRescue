using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class InputController : MonoBehaviour {

	private bool pressKeyToPlay;

	[SerializeField]
	private bool isKeyboard;

	public bool PressKeyToPlay 
	{
		get { return pressKeyToPlay; }
		set { pressKeyToPlay = value; }
	}

	private const string KEY_KEYBOARD = "space";
	private const float ZERO_TOUCH = 0;

	private float amountTouch;

	private void Update()
	{
		amountTouch = Input.touches.Length;
		ChooseConsole();
	}

	// Choose keyboard or touch
	private void ChooseConsole() 
	{
		if(!isKeyboard) 
		{
			CheckTouch();
		} 
		else 
		{
			pressKeyToPlay = Input.GetKey(KEY_KEYBOARD);
		}
	}

    private void CheckTouch() 
	{
		if(amountTouch > ZERO_TOUCH) 
		{
			pressKeyToPlay = true;
		} 
		else 
		{
			pressKeyToPlay = false;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour {
	public InputField inputField;
	private GameController controller;
	void Awake()
	{
		  controller = GetComponent<GameController>();

		  inputField.onEndEdit.AddListener(AcceptStringInput);
	}
	private void AcceptStringInput(string userInput)
	{
		userInput = userInput.ToLower();
		controller.LogStringWithReturn(userInput);

		char[] delimeterCharacters = { ' ' };
		string[] separatedInputWords = userInput.Split(delimeterCharacters);

		controller.Respond(separatedInputWords);

		InputComplete();
	}

	private void InputComplete()
	{
		controller.LogInteractable();
		controller.DisplayLoggedText();
		inputField.ActivateInputField();
		inputField.text = null;
	}
}

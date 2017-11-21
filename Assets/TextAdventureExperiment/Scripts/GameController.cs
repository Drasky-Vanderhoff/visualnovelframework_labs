using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public Text displayText;
	public Interactable initialInteractable;
	[HideInInspector] public Interactable currentInteractable;
	List<string> actionLog = new List<string>();

	void Start()
	{
		currentInteractable = initialInteractable;
		LogInteractable();
		DisplayLoggedText();
	}

	public void DisplayLoggedText(){
		string logAsText = string.Join("\n", actionLog.ToArray());

		displayText.text = logAsText;
	}

	public void Respond(string[] separatedInputWords){
		string result = null;
		Interactable newInteractable = currentInteractable.Respond(ref result, separatedInputWords);
		if(result != null)
			LogStringWithReturn(result);
		if(newInteractable != null)
			currentInteractable = newInteractable;
	}

	public void LogInteractable(){
		LogStringWithReturn(currentInteractable.detailedDescription);
		LogStringWithReturn(currentInteractable.interactionsDescriptions);
		for (int i = 0; i < currentInteractable.validInteractions.Length; i++)
			LogStringWithReturn(currentInteractable.validInteractions[i].description);

	}

	public void LogStringWithReturn(string stringToAdd){
		actionLog.Add(stringToAdd + "\n");
	}
}

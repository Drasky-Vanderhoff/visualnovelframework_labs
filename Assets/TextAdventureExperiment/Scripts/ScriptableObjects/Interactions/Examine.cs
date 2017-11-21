using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName="TextAdventure/Interactions/Examine")]
public class Examine : Interaction {
	public Interactable examinedInteractable;
	public override void RespondToInput(ref bool stopExecution, ref string output, 
										ref Interactable newInteractable, string[] separatedInputWords){
		stopExecution = keyword == separatedInputWords[0] && examinedInteractable.noun == separatedInputWords[1];

		if(stopExecution)
			output = success;
		else 
			output = failure;
	}

	public override void Respond(ref string output, ref Interactable newInteractable) {
		output = success;
	}
}

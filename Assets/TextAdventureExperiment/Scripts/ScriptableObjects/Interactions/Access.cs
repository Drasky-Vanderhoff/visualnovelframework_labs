using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName="TextAdventure/Interactions/Access")]
public class Access : Interaction {
	public override void RespondToInput(ref bool stopExecution, ref string output, 
										ref Interactable newInteractable, string[] separatedInputWords){
		stopExecution = keyword == separatedInputWords[0] && sucessfulResult.noun == separatedInputWords[1];

		if(stopExecution){
			output = success;
			newInteractable = sucessfulResult;
		} else {
			output = failure;
		}
	}

	public override void Respond(ref string output, ref Interactable newInteractable) {
		output = success;
		newInteractable = sucessfulResult;
	}
}

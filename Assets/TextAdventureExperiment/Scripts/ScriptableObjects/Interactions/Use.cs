using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName="TextAdventure/Interactions/Use")]
public class Use: Interaction {
	public override void RespondToInput(ref bool stopExecution, ref string output, 
										ref Interactable newInteractable, string[] separatedInputWords){
		stopExecution = keyword == separatedInputWords[0] && sucessfulResult.noun == separatedInputWords[1];

		if(stopExecution){
			output = success;
			newInteractable = sucessfulResult;
		}

		output = failure;
		newInteractable = null;
	}
	
	public override void Respond(ref string output, ref Interactable newInteractable) {
		output = success;
		newInteractable = sucessfulResult;
	}
}

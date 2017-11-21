using UnityEngine;
using System.Collections;

// TODO: Maybe i should rename this to State
[CreateAssetMenu(menuName="TextAdventure/Interactable")]
public class Interactable : ScriptableObject {
	public string noun = "name";
	[TextArea]
	public string description = "Description";
	[TextArea]
	public string detailedDescription = "Description";
	public string interactionsDescriptions = "Interactions :";
	public Interaction[] validInteractions;

	public Interactable Respond(ref string output, string[] separatedInputWords){
		bool stopExecution = false;
		Interactable newInteractable = this;
		for (int i = 0; i < validInteractions.Length && !stopExecution; i++){
			validInteractions[i].RespondToInput(ref stopExecution, ref output, ref newInteractable, separatedInputWords);
		}
		
		return newInteractable;
	}

	public Interactable Interact(ref string output, Interaction interaction){
		Interactable newInteractable = this;
		interaction.Respond(ref output, ref newInteractable);
		
		return newInteractable;
	}

}
using UnityEngine;

[System.Serializable]
public abstract class Interaction : ScriptableObject {
	public string keyword;
	public string description;
	public Interactable sucessfulResult;
	public string success;
	public string failure;

	// Must return null when it fails
	public abstract void RespondToInput(ref bool stopExecution, ref string output, 
										ref Interactable newInteractable, string[] separatedInputWords);

	public abstract void Respond(ref string output, ref Interactable newInteractable);
}

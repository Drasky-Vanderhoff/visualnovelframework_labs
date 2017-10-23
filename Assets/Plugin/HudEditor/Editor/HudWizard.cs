using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;

public class HudWizard : ScriptableWizard 
{
	public enum SizeValue {SMALL, MEDIUM, BIG};
	public enum Position {LEFT, MIDDLE, RIGHT};


	private static DialogHud dialogHud = null;

	public Sprite backgroundTexture;
	public Color backgroundColor = new Color32( 0x90, 0x90, 0x90, 0xFF );

	public Sprite characterTexture;
	public Position characterPosition = Position.MIDDLE;

	public bool showCharacterName = true;
	public Color characterNameColor = new Color32( 0xFF, 0xFF, 0xFF, 0x64 ); 
	public Font characterNameFont;
	//[Range(1,120)]
	private int characterNameFontSize = 14;

	public SizeValue characterNameSize = SizeValue.SMALL;


	public Color dialogColor = new Color32( 0xFF, 0xFF, 0xFF, 0x64 );
	public Font dialogFont;
	[Range(1,120)]
	public int dialogFontSize = 14;

	public Color optionsColor = new Color32( 0xFF, 0xFF, 0xFF, 0x64 );
	public Font optionsFont;
	[Range(1,120)]
	public int optionsFontSize = 14;



    [MenuItem ("My Tools/Hud Wizard")]
    static void CreateWizard()
    {
        HudWizard hudWizard = ScriptableWizard.DisplayWizard<HudWizard> ("Create Hud", "Create", "Update");
		if (dialogHud != null) {
			dialogHud = (DialogHud)((GameObject)GameObject.Find ("Dialog-Hud")).GetComponent<DialogHud> ();
			hudWizard.backgroundTexture = dialogHud.background.sprite;
			hudWizard.characterTexture = dialogHud.character.sprite;
			hudWizard.showCharacterName = dialogHud.characterNamePanel.active;
			hudWizard.backgroundColor = dialogHud.background.color;

			//Dialog components colors
			hudWizard.dialogColor = dialogHud.dialogPanel.GetComponent<Image>().color;
			hudWizard.characterNameColor = dialogHud.characterNamePanel.GetComponent<Image>().color;
			hudWizard.optionsColor = dialogHud.optionPanel.GetComponent<Image>().color;

			//Current font size
			hudWizard.characterNameFontSize = dialogHud.characterNamePanel.gameObject.GetComponentInChildren<Text> ().fontSize;
			hudWizard.dialogFontSize = dialogHud.dialogPanel.gameObject.GetComponentInChildren<Text> ().fontSize;
			hudWizard.optionsFontSize = dialogHud.optionPanel.gameObject.GetComponentInChildren<Text> ().fontSize;

			//Current font type
			hudWizard.characterNameFont = dialogHud.characterNamePanel.gameObject.GetComponentInChildren<Text> ().font;
			hudWizard.dialogFont = dialogHud.dialogPanel.gameObject.GetComponentInChildren<Text> ().font;
			hudWizard.optionsFont = dialogHud.optionPanel.gameObject.GetComponentInChildren<Text> ().font;
		}
    }


    void OnWizardCreate()
    {
		if (dialogHud != null) {
			DestroyImmediate (dialogHud);
		}
		dialogHud = (DialogHud) ((GameObject) Instantiate (Resources.Load ("DialogHud"))).GetComponent<DialogHud>();
		dialogHud.name = "Dialog-Hud";


		if (backgroundTexture != null) {
			dialogHud.background.sprite = backgroundTexture;
		}
		if (characterTexture != null) {
			dialogHud.character.sprite = characterTexture;
			UpdateCharacterPosition ();
		}
		dialogHud.characterNamePanel.SetActive (this.showCharacterName);
		UpdateSizes ();
		UpdateFonts ();
		UpdateColors ();
    }

	void OnWizardOtherButton()
	{
		if (dialogHud == null && GameObject.Find ("Dialog-Hud")) {
			dialogHud = (DialogHud)((GameObject)GameObject.Find ("Dialog-Hud")).GetComponent<DialogHud> ();
		}

		dialogHud.background.sprite = backgroundTexture;
		dialogHud.character.sprite = characterTexture;
		UpdateCharacterPosition ();
		dialogHud.characterNamePanel.SetActive (this.showCharacterName);
		UpdateSizes ();
		UpdateFonts ();
		UpdateColors ();

		EditorUtility.SetDirty(dialogHud);
	}


	void UpdateCharacterPosition()
	{
		switch (characterPosition) {
		case Position.LEFT:
			dialogHud.character.gameObject.GetComponent<RectTransform> ().anchoredPosition = new Vector2(0, 0);
			break;
		case Position.MIDDLE:
			dialogHud.character.gameObject.GetComponent<RectTransform> ().anchoredPosition = new Vector2(280, 0);
			break;
		case Position.RIGHT:
			dialogHud.character.gameObject.GetComponent<RectTransform> ().anchoredPosition = new Vector2(550, 0);
			break;
		}
	}

	void UpdateFonts()
	{
		//Font Size
		dialogHud.characterNamePanel.gameObject.GetComponentInChildren<Text> ().fontSize = this.characterNameFontSize;
		dialogHud.dialogPanel.gameObject.GetComponentInChildren<Text> ().fontSize = this.dialogFontSize;
		dialogHud.optionPanel.gameObject.GetComponentInChildren<Text> ().fontSize = this.optionsFontSize;

		//Font Type
		if (characterNameFont != null) {
			dialogHud.characterNamePanel.gameObject.GetComponentInChildren<Text> ().font = this.characterNameFont;
		}
		if (dialogFont != null) {
			dialogHud.dialogPanel.gameObject.GetComponentInChildren<Text> ().font = this.dialogFont;
		}
		if (optionsFont != null) {
			dialogHud.optionPanel.gameObject.GetComponentInChildren<Text> ().font = this.optionsFont;
		}
	}

	void UpdateColors()
	{
		dialogHud.background.color = backgroundColor;
		dialogHud.dialogPanel.GetComponent<Image>().color = dialogColor;
		dialogHud.characterNamePanel.GetComponent<Image>().color = characterNameColor;
		dialogHud.optionPanel.GetComponent<Image>().color = optionsColor;
	}

	void UpdateSizes()
	{
		int height = 30;
		int width = 100;
		switch (characterNameSize) {
		case SizeValue.SMALL:
			characterNameFontSize = 14;
			break;
		case SizeValue.MEDIUM:
			characterNameFontSize = 20;
			height = 40;
			width = 160;
			break;
		case SizeValue.BIG:
			characterNameFontSize = 40;
			height = 60;
			width = 200;
			break;
		}

		dialogHud.characterNamePanel.gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2(width, height);
	}

}
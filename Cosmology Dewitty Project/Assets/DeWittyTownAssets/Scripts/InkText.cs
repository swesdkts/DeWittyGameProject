using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InkText : MonoBehaviour
{
    public TextAsset inkJson;
    private Story story;

    public TextMeshProUGUI textPrefab;
    public Button buttonPrefab;

    // Start is called before the first frame update
    void Start()
    { 
        // A new story is created using the inkJson file set in the unity inspector.
        story = new Story(inkJson.text);

        refreshUI();
    }
    // Erase UI information
    void eraseUI()
    {
        for(int i = 0; i < this.transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }
    // Rebuild UI information
    void refreshUI()
    {
        eraseUI();
        // Instantiate text prefab, story text is loaded with the story from the Json file, set object location to parent location relative to parent
        TextMeshProUGUI storyText = Instantiate(textPrefab) as TextMeshProUGUI;
        storyText.text = loadStoryChunk();
        storyText.transform.SetParent(this.transform, false);

        // Get choices from Json file save them in an array
        foreach (Choice choice in story.currentChoices)
        {
            Button choiceButton = Instantiate(buttonPrefab) as Button;
            TextMeshProUGUI choiceText = buttonPrefab.GetComponentInChildren<TextMeshProUGUI>();
            choiceText.text = choice.text;
            choiceButton.transform.SetParent(this.transform, false);

            choiceButton.onClick.AddListener(delegate {
                chooseStoryChoice(choice);
            });
        }

    }

    void chooseStoryChoice(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        refreshUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Set text to an empty string if story.canContinue is true the text is set to the story and will continue until next set of choices.
    string loadStoryChunk()
    {
        string text = "";

        if (story.canContinue)
        {
           text = story.ContinueMaximally();
        }

        return text;
    }

}

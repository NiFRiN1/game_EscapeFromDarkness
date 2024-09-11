using UnityEngine;
using TMPro;


public class StoryData : MonoBehaviour
{
    public bool active = false;

    public string date;
    public string title;
    public string text;

    public TextMeshProUGUI titleTextMesh;
    public TextMeshProUGUI dateTextMesh;
    public TextMeshProUGUI textTextMesh;

    public TextMeshProUGUI ButtonStoryText;

    private string defButtonStoryText;

    private string defTitle;
    private string defData;
    private string defText; 

    private void Start()
    {
       defButtonStoryText = ButtonStoryText.text;

       defTitle = defButtonStoryText;
       defData = dateTextMesh.text;
       defText = textTextMesh.text;
    }

    private void Update()
    {
        if (active) {
            ButtonStoryText.text = $"> История: {title}";
        }
        else {
            ButtonStoryText.text = defButtonStoryText;
        }
    }

    public void setStory()
    {
        if (active) {
            dateTextMesh.text = "Дата: " + date;
            titleTextMesh.text = $"{title}";
            textTextMesh.text = text;
        }
        else {
            dateTextMesh.text = defData;
            titleTextMesh.text = defTitle.Replace("> ", ""); ;
            textTextMesh.text = defText;
        }
    }
}

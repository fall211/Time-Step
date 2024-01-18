using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class TextBoxPrompter : MonoBehaviour
{
    private GameObject textBoxPanel;
    private TextMeshProUGUI textField;
    private float timeSinceActive;
    private float showFor;
    // Start is called before the first frame update
    void Start() {
        textBoxPanel = GameObject.Find("TextBoxPanel");
        textField = textBoxPanel.GetComponentInChildren<TextMeshProUGUI>();
        textBoxPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update(){
        if (textBoxPanel.activeSelf){
            timeSinceActive += Time.deltaTime;
            if (timeSinceActive >= showFor) textBoxPanel.SetActive(false);
        }

        //if (Input.GetKeyUp(KeyCode.R)) PromptTextBox("Test", 5f);

    }

    public void PromptTextBox(String text, float showTime){
        showFor = showTime;
        timeSinceActive = 0f;
        if (textBoxPanel.activeSelf){
            textField.text = text;
        } else {
            textBoxPanel.SetActive(true);
            textField.text = text;
        }
    }
}

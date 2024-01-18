using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject textBoxPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject crosshair;

    [HideInInspector] public float look_sensitivity;
    // Start is called before the first frame update
    void Start()
    {
        settingsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ToggleSettingsMenu();
    }

    void ToggleSettingsMenu(){
        settingsPanel.SetActive(!settingsPanel.activeSelf);
        if (settingsPanel.activeSelf){
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            textBoxPanel.SetActive(false);
            crosshair.SetActive(false);
        } else {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            crosshair.SetActive(true);
        }
    }
}

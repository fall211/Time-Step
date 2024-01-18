using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float camera_sens = 10.0f;
    private float sensitivity_multiplier = 100.0f;
    public Transform player_transform;

    private float x_rotation;
    private float y_rotation;
    private TextBoxPrompter prompter;
    [SerializeField] private float rayCastDistance = 1f;
    [SerializeField] private GameObject settingsPanel;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        prompter = FindObjectOfType<TextBoxPrompter>();
    }

    // Update is called once per frame
    void Update() {
        
        if (Cursor.lockState == CursorLockMode.Locked) {
            float mouse_x = Input.GetAxis("Mouse X") * camera_sens * sensitivity_multiplier * Time.fixedDeltaTime;
            float mouse_y = Input.GetAxis("Mouse Y") * camera_sens * sensitivity_multiplier * Time.fixedDeltaTime;

            y_rotation += mouse_x;
            x_rotation -= mouse_y;
            x_rotation = Mathf.Clamp(x_rotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(x_rotation, y_rotation, 0);
    		player_transform.rotation  = Quaternion.Euler(0, y_rotation, 0);
        }



        if (Input.GetMouseButtonDown(0) && !settingsPanel.activeSelf){
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, rayCastDistance)){
                if (hit.transform.CompareTag("Interactable")){
                    TextItem textItem = hit.transform.gameObject.GetComponent<TextItem>();
                    prompter.PromptTextBox(textItem.text, textItem.duration);
                }
            }
        }
    }

    public void UpdateSens(float sens){
        camera_sens = sens;
    }
}

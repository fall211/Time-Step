using System;
using UnityEngine;

public class TimeTraveler : MonoBehaviour
{
    [SerializeField] private GameObject presentGameObj;
    [SerializeField] private GameObject pastGameObj;
    [SerializeField] private Light flashlight;
    float maxIntensity;
    float intensity;

    private bool transitioning = false;
    private readonly float transitionSpeed = 1f;
    private float transitionValue = 0f;
    bool canToggle = false;
    
    void Start(){
        maxIntensity = flashlight.intensity;
    }

    void Update(){
        
        if (!transitioning && Input.GetKeyDown(KeyCode.Tab)){
            transitioning = true;
            canToggle = true;
        }
        if (transitioning){
            transitionValue += Time.deltaTime * transitionSpeed;
            intensity = Mathf.Abs(transitionValue - maxIntensity);
            if (intensity < 0.1 && canToggle) {
                ToggleVisibleObjects();
                canToggle = false;
            }
            if (intensity > maxIntensity){
                intensity = maxIntensity;
                transitioning = false;
            }
            flashlight.intensity = intensity;
        } else {
            transitionValue = 0f;
        }
    }

    private void ToggleVisibleObjects(){
        presentGameObj.SetActive(!presentGameObj.activeSelf);
        pastGameObj.SetActive(!pastGameObj.activeSelf);

    }
}

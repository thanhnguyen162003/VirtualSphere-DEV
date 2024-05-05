using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShapeSpawner : MonoBehaviour
{
    public GameObject shapePrefab;
    public OVRInput.Button triggerButton = OVRInput.Button.PrimaryIndexTrigger;
    private float holdDuration = 0.3f;
    public float distanceInFront = 0.1f; // Distance in meters
    public GameObject LHand;
    public float scaleUpTime = 0.17f;

    private float triggerStartTime;
    private bool isTriggerPressed = false;
    private GameObject newShape;

    void Update()
    {

            if (OVRInput.GetDown(triggerButton))
            {
                triggerStartTime = Time.time;
                isTriggerPressed = true;
            // Calculate position in front of the controller

            Vector3 spawnPosition = LHand.transform.position + LHand.transform.forward * distanceInFront;
             newShape = Instantiate(shapePrefab, spawnPosition, LHand.transform.rotation);
            AudioSource audioSource = newShape.GetComponent<AudioSource>();
            audioSource.Play();
            // Start coroutine to animate scale
            StartCoroutine(ScaleUp(newShape, scaleUpTime));
        }
        //Debug.Log(holdDuration);
        if (OVRInput.GetUp(triggerButton))
        {
            isTriggerPressed = false;

            // Check if held long enough
            if (Time.time - triggerStartTime < holdDuration)
            {
               if(newShape != null)
                {
                    newShape.SetActive(false);
                }
            }
        }
    }


    IEnumerator ScaleUp(GameObject targetObject, float duration)
    {
        // Store the starting and target scales
        Vector3 startScale = Vector3.zero;
        Vector3 targetScale = targetObject.transform.localScale;

        // Animate over the specified duration
        float time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            float progress = time / duration;
            targetObject.transform.localScale = Vector3.Lerp(startScale, targetScale, progress);
            yield return null;
        }

        // Ensure final scale is reached
        targetObject.transform.localScale = targetScale;
    }
}
using System.Collections;
using UnityEngine;

public class TriggerShapeSpawnerRight : MonoBehaviour
{
    public GameObject shapePrefab;
    public OVRInput.Button triggerButton = OVRInput.Button.SecondaryIndexTrigger;
    private float holdDuration = 0.3f;
    public float distanceInFront = 0.1f; // Distance in meters
    public GameObject RHand;
    public float scaleUpTime = 0.2f;

    private float triggerStartTime;
    private bool isTriggerPressed = false;
    private GameObject newShape;

    void Update()
    {
        Vector3 spawnPosition = RHand.transform.position + RHand.transform.forward * distanceInFront;
        if (OVRInput.GetDown(triggerButton))
        {
            triggerStartTime = Time.time;
            isTriggerPressed = true;
            // Calculate position in front of the controller

            newShape = Instantiate(shapePrefab, spawnPosition, RHand.transform.rotation);
            if (newShape.TryGetComponent(out MindmapNode node))
            {
                node.AutoSetMindmapNodeGUID();
            }
            AudioSource audioSource = newShape.GetComponent<AudioSource>();
            if (audioSource != null) { audioSource.Play(); }
            // Start coroutine to animate scale
            //StartCoroutine(ScaleUp(newShape, scaleUpTime));
        }
        //Debug.Log(holdDuration);
        if (OVRInput.GetUp(triggerButton))
        {
            isTriggerPressed = false;

            // Check if held long enough
            if (Time.time - triggerStartTime < holdDuration)
            {
                if (newShape != null)
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

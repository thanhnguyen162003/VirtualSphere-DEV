using UnityEngine;
using Oculus.Platform;

public class OverlayGraphic : MonoBehaviour
{
    [SerializeField]
    private Transform targetGraphic;

    [SerializeField]
    private Transform linkedHandPosition;

    [SerializeField]
    private LayerMask layerToHit;


    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(linkedHandPosition.position, linkedHandPosition.forward, out hit, 10f, layerToHit))
        {
            targetGraphic.position = hit.point + hit.normal * 0.001f;
            targetGraphic.rotation = Quaternion.LookRotation(hit.normal);

            if(!targetGraphic.gameObject.activeInHierarchy) {
            targetGraphic.gameObject.SetActive(true);
            }
        }
        else
        {
            if (targetGraphic.gameObject.activeInHierarchy)
            {
                targetGraphic.gameObject.SetActive(false);
            }
        }
    }
}

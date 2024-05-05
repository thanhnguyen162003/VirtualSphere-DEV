using UnityEngine;

public class CanvasLookAtCamera : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothAmount = 1;
    [SerializeField] private float xAngleLimit = 55;

    private Transform head;
    private bool isPaused = false;

    void Start() => head = Camera.main.transform;

    private void OnEnable()
    {
        head = Camera.main.transform;
        UpdateTransform();
    }

    void Update()
    {
        if (!isPaused) UpdateTransform();
    }

    private void UpdateTransform()
    {

        float targetXRot = Mathf.Clamp(head.eulerAngles.x, -xAngleLimit, xAngleLimit);

        Quaternion targetRot = Quaternion.Euler(new Vector3(targetXRot, head.eulerAngles.y, 0));


        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime);
    }

    public void Pause() => isPaused = true;

    public void Resume() => isPaused = false;

    public void DestroyScript() => Destroy(this);
}

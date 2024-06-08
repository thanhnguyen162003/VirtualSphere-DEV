using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //[SerializeField] private Vector3 offset;
    [SerializeField] private float smoothAmount = 1;

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
        Quaternion targetRot = Quaternion.Euler(new Vector3(0, head.eulerAngles.y, 0));

        //transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smoothAmount);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * smoothAmount);
    }

    public void Pause() => isPaused = true;

    public void Resume() => isPaused = false;

    public void DestroyScript() => Destroy(this);
}

using UnityEngine;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] private Transform anchor;

    private Vector3 offset;

    private void Start() => offset = transform.localPosition;

    void Update()
    {
        if (anchor != null) 
            transform.position = anchor.position + offset;
    }
}

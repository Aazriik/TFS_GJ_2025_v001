using UnityEngine;

public class Interactable : MonoBehaviour
{
    public new string name;

    public string objectType;

    public bool collected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Trigger item pick up availability code //
    }
}

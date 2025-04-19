using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject destroyedVersion;

    public void TriggerDestruction()
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject); // Unity's built-in Destroy is now clearly called
    }
}
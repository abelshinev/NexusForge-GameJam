using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PowerUpScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject PowerUp;
    public ScoringScript Score;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Apply an upward force
            // rb.AddForce(Vector3.up * 1000f); // Adjust the force as needed
            Debug.Log("Launched " + other.name + " into the air!");
            PowerUp.SetActive(false);
            Score.AddScore();
        }
    }
}

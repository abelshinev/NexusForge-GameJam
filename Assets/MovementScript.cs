using UnityEngine;

public class MovementScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Rigidbody Body;

    public float forceStrength = 1000f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Body.AddForce(-500 * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Body.AddForce(500 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Body.AddForce(0, 0, 500 * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Body.AddForce(0, 0, -500 * Time.deltaTime);
        }
    }
}

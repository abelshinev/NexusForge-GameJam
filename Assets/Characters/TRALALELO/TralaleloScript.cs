using UnityEngine;
using UnityEngine.UIElements;

public class TralaleloScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody shark;
    public float movementForce = 500f;
    public float maxSpeed = 4f;

    public Vector3 spawnPoint = new Vector3(0, 3, -12);
    void Start()
    {
        transform.position = spawnPoint;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 force = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            force += new Vector3(0, 0, movementForce * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            force += new Vector3(-movementForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            force += new Vector3(0, 0, -movementForce * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            force += new Vector3(movementForce * Time.deltaTime, 0, 0);
        }

        // Apply force
        shark.AddForce(force);

        // Clamp max speed (XZ plane only, so Y stays for gravity/jumps)
        Vector3 flatVelocity = new Vector3(shark.linearVelocity.x, 0, shark.linearVelocity.z);
        if (flatVelocity.magnitude > maxSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * maxSpeed;
            shark.linearVelocity = new Vector3(limitedVelocity.x, shark.linearVelocity.y, limitedVelocity.z);
        }

    }
}

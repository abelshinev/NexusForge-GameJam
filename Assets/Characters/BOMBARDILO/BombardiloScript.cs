using UnityEngine;
using UnityEngine.UIElements;

public class BombardiloScript : MonoBehaviour
{
    public Rigidbody croc;
    public float movementForce = 500f;
    public float maxSpeed = 4f;

    public Vector3 spawnPoint = new Vector3(0, 10, -12);

    public GameObject grenadePrefab;
    private GameObject reusableGrenade;

    public float grenadeDropForce = 5f;
    public float grenadeDropOffset = 1f;

    void Start()
    {
        croc.position = spawnPoint;

        // Create the grenade once and deactivate it
        if (grenadePrefab != null)
        {
            reusableGrenade = Instantiate(grenadePrefab, transform.position, Quaternion.identity);
            reusableGrenade.SetActive(false);
        }
    }

    void Update()
    {
        Vector3 force = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            force += new Vector3(0, 0, movementForce * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            force += new Vector3(-movementForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            force += new Vector3(0, 0, -movementForce * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            force += new Vector3(movementForce * Time.deltaTime, 0, 0);
        }

        croc.AddForce(force);

        Vector3 flatVelocity = new Vector3(croc.linearVelocity.x, 0, croc.linearVelocity.z);
        if (flatVelocity.magnitude > maxSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * maxSpeed;
            croc.linearVelocity = new Vector3(limitedVelocity.x, croc.linearVelocity.y, limitedVelocity.z);
        }

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            DropReusableGrenade();
        }
    }

    void DropReusableGrenade()
    {
        if (reusableGrenade != null)
        {
            // Reactivate grenade
            reusableGrenade.SetActive(true);

            // Reset position & rotation
            reusableGrenade.transform.position = transform.position - new Vector3(0, grenadeDropOffset, 0);
            reusableGrenade.transform.rotation = Quaternion.identity;

            // Reset physics
            Rigidbody rb = reusableGrenade.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.AddForce(Vector3.down * grenadeDropForce, ForceMode.Impulse);
            }
        }
    }
}

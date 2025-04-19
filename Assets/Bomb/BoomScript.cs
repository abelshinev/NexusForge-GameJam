using UnityEngine;
using UnityEngine.Video;

public class BoomScript : MonoBehaviour
{
    [Header("Explosion Timing")]
    public float delay = 3f;
    private float countdown;
    private bool hasExploded = false;

    [Header("Explosion Settings")]
    public GameObject explosionEffect;
    public float explosionDuration = 2f;
    public float radius = 5f;
    public float force = 700f;

    [Header("Destruction Settings")]
    public GameObject destroyedVersion; // optional broken version of the object

    public GameObject ScoringScreen;
    public GameObject LoseScreen;
    public GameObject LostCredits;
    public OuttroScript outscript;

    bool readyToPlayCutscene = false;

    void Start()
    {
        countdown = delay;
    }

    void OnEnable()
    {
        countdown = delay;
        hasExploded = false;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }

    
        if (Input.GetKeyDown(KeyCode.C) && readyToPlayCutscene == true)
        {
            Debug.Log("READY TO PLAY");
            LostCredits.SetActive(true);
            outscript.Begin();
            readyToPlayCutscene = false;
        }


    }

    void Explode()
    {
        // Create explosion VFX
        if (explosionEffect != null)
        {
            GameObject fx = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(fx, explosionDuration);
        }

        // Apply force & destroy nearby destructibles
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }

            // If nearby object has this script attached, trigger destruction
            BoomScript destruct = nearbyObject.GetComponent<BoomScript>();
            if (destruct != null && destruct != this) // prevent self-recursion
            {
                destruct.TriggerDestruction();
            }
        }

        Debug.Log("BOOM");

        // Destroy this grenade object
        gameObject.SetActive(false);
    }

    public void TriggerDestruction()
    {
        if (destroyedVersion != null)
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
        }

        gameObject.SetActive(false);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<TralaleloScript>() != null)
        {
            Debug.Log("Grenade hit TralaleloTralala! Game over.");
            ScoringScreen.SetActive(false);
            LoseScreen.SetActive(true);
            readyToPlayCutscene = true;
        }
    }
}

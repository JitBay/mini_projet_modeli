using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    [Header("Grenade Settings")]
    public GameObject grenadePrefab;
    public Transform handTransform;
    public float initialForce = 65f;
    public float airResistance = 0.02f;
    public float bounciness = 0.5f;
    public float respawnDelay = 2f;

    private GameObject currentGrenade;

    private Animator anim;

    private void Start()
    {
        RespawnGrenade();

        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) // Replace with your desired input
        {
            anim.SetTrigger("Throw");
        }
    }
    public void ThrowGrenadeFunction()
    {
        if (currentGrenade != null)
        {
            ThrowGrenade();
        }
    }
    private void ThrowGrenade()
    {
        GrenadePhysics gP = currentGrenade.GetComponent<GrenadePhysics>();
        Rigidbody rb = currentGrenade.GetComponent<Rigidbody>();

        if ((gP != null))
        {
            gP.smokeEffect.SetActive(true);
        }
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.AddForce(transform.forward * initialForce, ForceMode.VelocityChange);
            rb.AddTorque(Random.insideUnitSphere * 10f, ForceMode.VelocityChange);
        }

        currentGrenade.transform.parent = null;
        currentGrenade = null;
        Invoke(nameof(RespawnGrenade), respawnDelay);
        
    }

    private void RespawnGrenade()
    {
        currentGrenade = Instantiate(grenadePrefab, handTransform.position, handTransform.rotation);
        currentGrenade.transform.parent = handTransform;
        Rigidbody rb = currentGrenade.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }
}
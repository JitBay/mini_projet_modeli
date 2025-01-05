using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GrenadePhysics : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 lastVelocity;

    [Header("Physics Settings")]
    public float airResistance = 0.02f;
    public float bounciness = 0.5f;

    [SerializeField] private GameObject fog;
    [SerializeField] public GameObject smokeEffect;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    //private void FixedUpdate()
    //{
    //    ApplyAirResistance();
    //}

    private void ApplyAirResistance()
    {
        if (rb.velocity.magnitude > 0)
        {
            Vector3 resistance = -rb.velocity.normalized * airResistance * rb.velocity.sqrMagnitude;
            rb.AddForce(resistance, ForceMode.Force);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 reflection = Vector3.Reflect(lastVelocity, collision.contacts[0].normal);
        rb.velocity = reflection * bounciness;
        Instantiate(fog, collision.contacts[0].thisCollider.transform.position, Quaternion.identity);
        //gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    //private void LateUpdate()
    //{
    //    lastVelocity = rb.velocity;
    //}
}
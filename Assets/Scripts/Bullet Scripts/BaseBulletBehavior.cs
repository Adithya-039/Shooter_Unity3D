using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBulletBehavior : MonoBehaviour
{
    public float bulletSpeed = 6f;
    public Rigidbody bulletRigidBody;
    private Vector3 direction;
    public float bulletdamage = 5f;
    // Start is called before the first frame update
    

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Deteched");
        collision.gameObject.GetComponent<HealthAndDamage>().AcceptDamge(bulletdamage);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        bulletRigidBody.AddForce(direction * 3f);

        RaycastHit rayHit;

        if (Physics.Raycast(transform.position, bulletRigidBody.velocity.normalized, out rayHit, bulletRigidBody.velocity.magnitude * 0.02f))
        {
            rayHit.transform.gameObject.GetComponent<HealthAndDamage>().AcceptDamge(bulletdamage);
            
            Destroy(gameObject);
        }

        Debug.DrawLine(transform.position, transform.position + bulletRigidBody.velocity);
    }

    public void SetBulletDirection(Vector3 desiredDirection)
    {
        direction = desiredDirection;
    }
}

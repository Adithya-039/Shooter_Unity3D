using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    Vector2 movementValues = Vector2.zero;
    Vector2 LookingValues = Vector2.zero;
    public float frameDistance = 1f;
    //public float forceAmount = 1;
    public float mass = 20;
    public float TurnSpeed = 2f;
    //public Rigidbody rbBody;

    public GameObject bulletPrefab;
    public float shootingFrequenvy = 1f;
    public float shootTimer = 0f;
    public HealthAndDamage hdComponent;

    public void IAAccelerate(InputAction.CallbackContext context)
    {
         movementValues = context.ReadValue<Vector2>();
        
    }

    public void IALooking(InputAction.CallbackContext context)
    {
        LookingValues = context.ReadValue<Vector2>();
        Debug.Log("Looking Around");

        transform.Rotate(transform.up, LookingValues.x * Time.deltaTime * TurnSpeed);

    }
    public void IAShoot(InputAction.CallbackContext context)
    {
        if(context.started == true)
        {
            shoot();
        }
    }

    private void Awake()
    {
        hdComponent = gameObject.GetComponent<HealthAndDamage>();

    }

    // Start is called before the first frame update 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementValues.x * frameDistance * Time.deltaTime, 0, movementValues.y * frameDistance * Time.deltaTime);
        //rbBody.AddForce(movementValues.x * frameDistance * Time.deltaTime, 0, movementValues.y * frameDistance * Time.deltaTime);
        //rbBody.mass = mass;

    }

    public void shoot()
    {
        GameObject spawnedBullet;
        Vector3 direction = (transform.forward * 100f) - transform.position;
        spawnedBullet = Instantiate(bulletPrefab, transform.position + transform.forward, Quaternion.identity);
        spawnedBullet.GetComponent<BaseBulletBehavior>().SetBulletDirection(direction);

        spawnedBullet.GetComponent<BaseBulletBehavior>().bulletdamage = hdComponent.damage;
    }

}



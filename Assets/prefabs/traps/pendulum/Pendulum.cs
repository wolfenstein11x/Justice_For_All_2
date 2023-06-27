using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [SerializeField] float maxAngle = 30.0f;
    [SerializeField] float offset = 0f;
    [SerializeField] float speed = 1.0f;
    [SerializeField] float damage = 10f;
    [SerializeField] AudioSource hitSound;

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float angle = maxAngle * Mathf.Sin((Time.time + offset) * speed);
        gameObject.transform.localRotation = Quaternion.Euler(0, 0, angle);
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            hitSound.Play();
            playerHealth.TakeDamage(damage);
        }
    }
}

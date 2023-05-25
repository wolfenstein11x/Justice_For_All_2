using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Vector3 movementVec;
    [SerializeField] [Range(0, 1)] float movementFactor;
    [SerializeField] float period = 2f;

    Vector3 startingPos;
    PlayerController pc;


    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        pc = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        float rawSineWave = Mathf.Sin(cycles * tau);

        movementFactor = (rawSineWave + 1f) / 2f;

        Vector3 offset = movementVec * movementFactor;

        transform.position = startingPos + offset;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pc.gameObject.transform.SetParent(transform);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pc.gameObject.transform.SetParent(null);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupShooter : MonoBehaviour
{
    [SerializeField] PowerupBlast[] powerupBlasts;
    [SerializeField] AudioSource blastSound;
    [SerializeField] float blastSoundDuration = 0.755f;
    [SerializeField] Transform shootPoint;

    private OrientationTracker orientationTracker;

    // Start is called before the first frame update
    void Start()
    {
        orientationTracker = GetComponent<OrientationTracker>();
    }

    // 0 is green blast, 1 is blue blast, 2 is purple blast
    public void ShootPowerupBlast(int powerupIdx)
    {
        AudioSource blastSoundInstance = Instantiate(blastSound, transform.position, transform.rotation);
        Destroy(blastSoundInstance, blastSoundDuration);
        
        PowerupBlast powerupBlast = Instantiate(powerupBlasts[powerupIdx], shootPoint.position, powerupBlasts[powerupIdx].transform.rotation);
        powerupBlast.transform.parent = gameObject.transform;
    }
}

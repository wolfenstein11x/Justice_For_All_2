using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elite : MonoBehaviour
{
    Talker talker;

    // Start is called before the first frame update
    void Start()
    {
        talker = GetComponent<Talker>();
    }

    // Update is called once per frame
    void Update()
    {
        talker.TalkerUpdate();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    
    [SerializeField] Key key;
    

    private void Awake()
    {
        key.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void ProcessDeath()
    {
        key.gameObject.SetActive(true);
    }
}

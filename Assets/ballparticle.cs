using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballparticle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyParticle", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void destroyParticle()
    {
        Destroy(gameObject);
    }

}

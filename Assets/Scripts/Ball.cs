using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody ballRb;
    private Renderer ballRenderer;
    // Start is called before the first frame update
    void Start()
    {
        float scaleBall = Random.Range(.2f, .35f);
        transform.localScale = new Vector3(scaleBall, scaleBall, scaleBall);
        ballRb = GetComponent<Rigidbody>();
        ballRenderer = GetComponent<Renderer>();

        ballRenderer.material.color = RandomColourVector3();
        ballRb.AddForce(RandomForceVector(), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomForceVector()
    {
        Vector3 forceVector = new Vector3(Random.Range(-.3f, .3f), Random.Range(-.3f, -1f));
        return forceVector;
    }

    Color RandomColourVector3()
    {
        Color randColour = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 255));
        return randColour;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CollisionScore"))
        {
            other.GetComponent<ScoreCollider>().scoreUpdate(1);
            Debug.Log("Entered");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CollisionScore"))
        {
            other.GetComponent<ScoreCollider>().scoreUpdate(-1);
        }
    }
}
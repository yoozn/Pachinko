using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody ballRb;
    private Renderer ballRenderer;
    [SerializeField] ParticleSystem ballParticles;
    [SerializeField] AudioClip collision1;
    [SerializeField] AudioClip collision2;
    [SerializeField] AudioClip score;
    private AudioSource audioSource;
    private bool scored = false;
    // Start is called before the first frame update
    void Start()
    {
        Color randomColor = RandomColourVector3();
        float scaleBall = Random.Range(.2f, .35f);
        transform.localScale = new Vector3(scaleBall, scaleBall, scaleBall);
        ballRb = GetComponent<Rigidbody>();
        ballRenderer = GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();

        ballRenderer.material.color = randomColor;
        ballRb.AddForce(RandomForceVector(), ForceMode.Impulse);
        var main = ballParticles.main;
        main.startColor = randomColor;
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
            audioSource.PlayOneShot(score);
            scored = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CollisionScore"))
        {
            other.GetComponent<ScoreCollider>().scoreUpdate(-1);
            scored = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(ballParticles, transform.position, transform.rotation);
        randomCollisionSound();
    }

    private void randomCollisionSound()
    {
        if (scored == false)
        {
            int randomNum = Random.Range(0, 1);
            if (randomNum == 1)
            {
                audioSource.PlayOneShot(collision1);
            }
            else
            {
                audioSource.PlayOneShot(collision2);
            }
        }
        
    }
}

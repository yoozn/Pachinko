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
    [SerializeField] AudioClip scoreSound2;
    [SerializeField] AudioClip scoreSound3;
    [SerializeField] AudioClip scoreSound4;
    [SerializeField] AudioClip score;
    private AudioSource audioSource;
    private bool scored = false;
    private GameManager gameManager;
    private Color randomColor;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        randomColor = RandomColourVector3();

        //scale of ball. un comment below to set to random values.

        //float scaleBall = Random.Range(.2f, .35f);
        float scaleBall = .25f;


        transform.localScale = new Vector3(scaleBall, scaleBall, scaleBall);
        ballRb = GetComponent<Rigidbody>();
        ballRenderer = GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();

        ballRenderer.material.color = randomColor;


        //ballRb.AddForce(RandomForceVector(), ForceMode.Impulse);
        ballRb.AddForce(Vector3.down, ForceMode.Impulse);
        audioSource.volume = SaveAndLoad.instance.gameVolume / 5;

        //var main = ballParticles.main;
        //main.startColor = randomColor;
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
        Color randColour = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        return randColour;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CollisionScore"))
        {
            other.GetComponent<ScoreCollider>().scoreUpdate(1);
            other.GetComponent<ScoreCollider>().ScoreParticles();
            audioSource.PlayOneShot(score);
            scored = true;
            gameManager.startingBalls -= 1;
            int randomNum = Random.Range(0, 3);
            if (randomNum == 0)
            {
                audioSource.PlayOneShot(scoreSound2);
            } else if (randomNum == 1)
            {
                audioSource.PlayOneShot(scoreSound3);
            }
            else if (randomNum == 2)
            {
                audioSource.PlayOneShot(scoreSound4);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CollisionScore"))
        {
            other.GetComponent<ScoreCollider>().scoreUpdate(-1);
            scored = false;
            gameManager.startingBalls += 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Instantiate(ballParticles, transform.position, transform.rotation);
        particleInstance();
        randomCollisionSound();
    }

    private void randomCollisionSound()
    {
        if (scored == false)
        {
            int randomNum = Random.Range(0, 2);
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

    private void particleInstance()
    {
        var particleInstance = Instantiate(ballParticles, transform.position, ballParticles.transform.rotation);
        var particleMain = particleInstance.main;
        particleMain.startColor = randomColor;
    }

}

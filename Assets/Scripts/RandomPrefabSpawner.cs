using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPrefabSpawner : MonoBehaviour
{
    [SerializeField] GameObject pegs1;
    [SerializeField] GameObject pegs2;
    [SerializeField] GameObject pegs3;
    [SerializeField] GameObject paddle;
    [SerializeField] GameObject paddleCross;
    // Start is called before the first frame update
    void Start()
    {
        var randNum = Random.Range(0, 7);
        Debug.Log(randNum);
        switch (randNum)
        {
            case 0:
                Instantiate(pegs1, transform.position, pegs1.transform.rotation);
                break;
            case 1:
                Instantiate(pegs2, transform.position, pegs2.transform.rotation);
                break;
            case 2:
                Instantiate(pegs3, transform.position, pegs3.transform.rotation);
                break;
            case (< 5):
                Instantiate(paddle, transform.position, paddle.transform.rotation);
                break;
            case (< 7 ):
                Instantiate(paddleCross, transform.position + new Vector3(0, 0, -.15f), paddleCross.transform.rotation);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

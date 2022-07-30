using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCollider : MonoBehaviour
{
    [SerializeField] private int value;
    [SerializeField] TextMeshProUGUI valueText;
    private Renderer colourRenderer;
    [SerializeField] Vector4 colorValue;
    private GameManager gameManager;
    [SerializeField] ParticleSystem scoreColliderParticle1;
    [SerializeField] ParticleSystem scoreColliderParticle2;

    private Color colourValue;
    // Start is called before the first frame update
    void Start()
    {
        colourValue = new Color(colorValue.x, colorValue.y, colorValue.z, colorValue.w);
        //var main = scoreColliderParticle1.main;
        //main.startColor = new Color(Mathf.Abs(colorValue.x), Mathf.Abs(colorValue.y), Mathf.Abs(colorValue.z), Mathf.Abs(colorValue.w));
        //Debug.Log(colourValue);
        //Debug.Log(main.startColor);




        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        colourRenderer = GetComponent<Renderer>();
        valueText.text = value.ToString();
        //Invoke("ScoreParticles", 5);
        colourRenderer.material.color = colourValue;
        //Debug.Log(colourRenderer.material.color);
    }

    // Update is called once per frame
    void Update()
    {


        //Debug.Log(colorValue);
    }

    public void scoreUpdate(int num)
    {
        gameManager.UpdateScore(value * num);
        Debug.Log(value);
    }

    public void ScoreParticles()
    {
        var newColourValue = new Color(colorValue.x, colorValue.y, colorValue.z, .63f);
        var scoreParticles = Instantiate(scoreColliderParticle1, transform.position + new Vector3(0, .75f, 0), scoreColliderParticle1.transform.rotation);
        var scoreParticlesMain = scoreParticles.main;
        scoreParticlesMain.startColor = newColourValue;
        Instantiate(scoreColliderParticle2, transform.position + new Vector3(0, .75f, 0), scoreColliderParticle2.transform.rotation);
    }    
}

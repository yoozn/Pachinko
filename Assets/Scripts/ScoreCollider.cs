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
    // Start is called before the first frame update
    void Start()
    {
        var main = scoreColliderParticle1.main;
        main.startColor = new Color(colorValue.x, colorValue.y, colorValue.z);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        colourRenderer = GetComponent<Renderer>();
        valueText.text = value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        colourRenderer.material.color = new Color(colorValue.x, colorValue.y, colorValue.z, colorValue.w);
    }

    public void scoreUpdate(int num)
    {
        gameManager.UpdateScore(value * num);
        Debug.Log(value);
    }

    public void ScoreParticles()
    {
        Instantiate(scoreColliderParticle1, transform.position, scoreColliderParticle1.transform.rotation);
    }    
}

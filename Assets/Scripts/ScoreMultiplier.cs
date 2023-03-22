using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplier : MonoBehaviour
{
   
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Boss_Head")
        {
            gameManager.score *= 3;
            gameManager.gameFinish = true;

        }
        if (collision.gameObject.tag == "Boss_Body")
        {
            gameManager.score *= 2;
            gameManager.gameFinish = true;
        }
    }
}

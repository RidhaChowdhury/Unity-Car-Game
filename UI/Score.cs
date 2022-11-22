using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public Transform player;
    public CarController car;
    public TMP_Text scoreText;
    private float multiplier = 1;
    private float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void increaseMultiplier(float amount)
    {
        multiplier += amount;
    }

    // Update is called once per frame
    void Update()
    {
        score += car.currentSpeed * Time.deltaTime * 0.5f * multiplier;
        scoreText.text = ((int)(score)).ToString();
    }
}

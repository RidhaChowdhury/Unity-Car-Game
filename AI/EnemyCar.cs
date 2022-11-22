using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    //Movement Script 
    AIMovement carMovement;

    // Start is called before the first frame update
    void Start()
    {
        carMovement = this.GetComponent<AIMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

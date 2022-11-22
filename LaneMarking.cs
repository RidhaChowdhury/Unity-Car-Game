using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneMarking : MonoBehaviour
{
    [SerializeField] float lineLength = 2f;
    [SerializeField] int lineCount = 10;
    LineRenderer line;
    
    // Start is called before the first frame update
    void Start()
    {
        line = this.GetComponent<LineRenderer>();
        line.positionCount = lineCount;
        UpdateLinePositions();
    }

    private void Update() {
        UpdateLinePositions();
    }
    // Update line positions
    void UpdateLinePositions() {
        for(int l = 1; l < lineCount; l++) {
            line.SetPosition(l*2, new Vector3(this.transform.position.x, l * lineLength, -(l%2)+2));
            line.SetPosition(l*2-1, new Vector3(this.transform.position.x, l * lineLength, (l%2)-2));
        }
    }

    void Scroll(float delta) {

    }
}

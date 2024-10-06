using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public Transform player, topLeft, topRight, top, bottomLeft, bottomRight, bottom, middleLeft, middleRight, middle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player.position.x > middleRight.position.x) {
            topLeft.position = new Vector3(topRight.position.x + 64, topRight.position.y, topRight.position.z);
            middleLeft.position = new Vector3(middleRight.position.x + 64, middleRight.position.y, middleRight.position.z);
            bottomLeft.position = new Vector3(bottomRight.position.x + 64, bottomRight.position.y, bottomRight.position.z);
            Transform newTopRight = topLeft;
            Transform newMiddleRight = middleLeft;
            Transform newBottomRight = bottomLeft;
            topLeft = top;
            middleLeft = middle;
            bottomLeft = bottom;
            top = topRight;
            middle = middleRight;
            bottom = bottomRight;
            topRight = newTopRight;
            middleRight = newMiddleRight;
            bottomRight = newBottomRight;
        } else if(player.position.x < middleLeft.position.x) {
            topRight.position = new Vector3(topLeft.position.x - 64, topLeft.position.y, topLeft.position.z);
            middleRight.position = new Vector3(middleLeft.position.x - 64, middleLeft.position.y, middleLeft.position.z);
            bottomRight.position = new Vector3(bottomLeft.position.x - 64, bottomLeft.position.y, bottomLeft.position.z);
            Transform newTopRLeft = topRight;
            Transform newmiddleLeft = middleRight;
            Transform newBottomLeft = bottomRight;
            topRight = top;
            middleRight = middle;
            bottomRight = bottom;
            top = topLeft;
            middle = middleLeft;
            bottom = middleRight;
            topLeft = newTopRLeft;
            middleLeft = newmiddleLeft;
            bottomLeft = newBottomLeft;
        }
    }

    void Shift(bool right, Transform background) {

    }
}

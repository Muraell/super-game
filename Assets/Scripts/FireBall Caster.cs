using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCaster : MonoBehaviour
{
    public FireBallScript FireBall;
    public Transform FireBallSourceTransform;
     private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(FireBall, FireBallSourceTransform.position, FireBallSourceTransform.rotation);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    public float degreesPerSecond = 30f;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, degreesPerSecond) * Time.deltaTime);
    }
}

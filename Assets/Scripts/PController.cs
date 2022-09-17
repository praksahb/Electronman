using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PController : MonoBehaviour
{
    [SerializeField]
    private GameObject protonplayer;

    private void Update()
    {
        Debug.Log(protonplayer.transform.position);
        transform.RotateAround(protonplayer.gameObject.transform.position, Vector3.forward, 600 * Time.deltaTime);
    }

}

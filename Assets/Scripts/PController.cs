using UnityEngine;

public class PController : MonoBehaviour
{
    [SerializeField]
    private GameObject protonplayer;

    private Transform pTransform;

    //use here but create inside PMC
    private int chargeValue;

    private void Awake()
    {
        pTransform = gameObject.transform;
    }

    private void Update()
    {
       // Debug.Log(pTransform.rotation.eulerAngles.z);
        transform.RotateAround(protonplayer.gameObject.transform.position, Vector3.back, 250 * Time.deltaTime);

        //delta margin for counting rotation laps - 5 or 4.5 for speed = 500
        if (pTransform.rotation.eulerAngles.z >= 90 && pTransform.rotation.eulerAngles.z <= 92)
        {
            chargeValue++;
            Debug.Log("Charge value: " + chargeValue);
        }
    }
}
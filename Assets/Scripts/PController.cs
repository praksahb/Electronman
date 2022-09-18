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
        //Debug.Log(pTransform.localEulerAngles);
        transform.RotateAround(protonplayer.gameObject.transform.position, Vector3.back, 60 * Time.deltaTime);

        if(pTransform.localEulerAngles.z == 90)
        {
            chargeValue++;
            Debug.Log("Charge value: " + chargeValue);
        }
    }

}

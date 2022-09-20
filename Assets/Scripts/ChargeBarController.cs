using UnityEngine.UI;
using UnityEngine;

public class ChargeBarController : MonoBehaviour
{

    [SerializeField]
    private Image chargeBar;

    public PlayerMovementController playerMovementController;

    public PController playerObjCompanion;

    private void Awake()
    {
        UpdateChargeBar();
    }

    private void Update()
    {
        UpdateChargeBar();
    }

    public void UpdateChargeBar()
    {
        chargeBar.fillAmount = Mathf.Clamp(playerMovementController.GetChargeValue(), 0, 1);
    }
}
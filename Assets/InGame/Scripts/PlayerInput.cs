using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private BallController _ballController;
    void Start()
    {
        _ballController = GetComponent<BallController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
        }

        if (Input.GetButton("Fire1"))
        {
            _ballController.ShotPowerRoulette();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            _ballController.ShotBall();
        }
        if (Input.GetButtonDown("Cancel"))
        {
            if (Cursor.visible)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }

    }
}

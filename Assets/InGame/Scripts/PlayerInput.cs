using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] BallController ballController;
    void Start()
    {
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
            ballController.ShotPowerRoulette();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            ballController.ShotBall();
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


using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    private Vector2 newLook;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform orientation;
    [SerializeField] private float speedMultiplayer = 1f;

    private void Start()
    {
        orientation.transform.rotation = Quaternion.Euler(0, default , 0);
    }
    public void OnLook(InputValue input)
    {
        newLook = InputManager.Instance.GetLookValue(input);

        newLook = new Vector2(newLook.y * speedMultiplayer * Time.deltaTime, newLook.x * speedMultiplayer * Time.deltaTime);

        transform.Rotate(newLook);
    }
}

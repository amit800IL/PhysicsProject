using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    private Vector2 newLook;
    [SerializeField] private float lookSpeed;
    [SerializeField] Camera cam;
    [SerializeField] private GameObject hand;

    public void OnLook(InputValue input)
    {
        newLook = InputManager.Instance.GetLookValue(input);

        newLook = new Vector2(-newLook.y * lookSpeed * Time.deltaTime, newLook.x * lookSpeed * Time.deltaTime);

        cam.transform.Rotate(newLook * lookSpeed * Time.deltaTime);
        hand.transform.Rotate(newLook * lookSpeed * Time.deltaTime);

        cam.transform.rotation = hand.transform.rotation;
    }


}

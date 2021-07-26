using UnityEngine;

public class InputController : MonoBehaviour
{
    public float horizontal { get; private set; }
    public float vertical { get; private set; }

    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
    }
}

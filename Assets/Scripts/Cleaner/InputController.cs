using UnityEngine;

public class InputController : MonoBehaviour
{
    public float horizontal { get; private set; }
    public float vertical { get; private set; }

    public bool attack { get; private set; }
    public bool jump { get; private set; }

    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        attack = Input.GetMouseButtonDown(0);
        jump = Input.GetKeyDown(KeyCode.Space);
    }
}

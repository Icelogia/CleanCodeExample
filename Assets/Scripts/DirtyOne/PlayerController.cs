using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Animator _animator;
    [SerializeField] GameObject weaponcolliderobj;
    int comboStep = 0;

    [SerializeField] Transform _trans;
    [SerializeField] CharacterController _controller;
    [SerializeField] float rSpd;

    Vector3 _movementVector;
    bool canMove = true;
    float horizontal;
    float vertical;
    bool attack;
    bool skok;

    private void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        attack = Input.GetMouseButtonDown(0);
        skok = Input.GetKeyDown(KeyCode.Space);

        if (skok && canMove)
        {
            _animator.SetTrigger("skok");
        }

        if (attack)
        {
            if (comboStep != 0)
            {
                weaponcolliderobj.SetActive(false);
                canMove = false;
                _animator.SetBool("isDoingCombo", true);
                weaponcolliderobj.SetActive(true);
                
            }

            if (comboStep == 0)
            {
                canMove = false;
                _animator.SetBool("isDoingCombo", false);
                _animator.SetTrigger("attack");
                comboStep++;
                weaponcolliderobj.SetActive(true);
            }
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            _movementVector = 5 * _trans.forward * vertical;
            if (vertical > 0.1)
            {
                _controller.Move(_movementVector * Time.fixedDeltaTime);
            }
            else if (vertical < -0.1)
            {
                _controller.Move(_movementVector * 0.5f * Time.fixedDeltaTime);
            }

            _animator.SetFloat("speed", vertical);

            _trans.Rotate(Vector3.up * horizontal * Time.fixedDeltaTime * rSpd);
        }
    }

    public void ResetCombo()
    {
        weaponcolliderobj.SetActive(false);
        comboStep = 0;
        _animator.Play("Idle");
        _animator.SetBool("isDoingCombo", false);
        canMove = true;
    }
}



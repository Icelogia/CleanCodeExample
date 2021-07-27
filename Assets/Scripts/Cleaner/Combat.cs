using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private Animator _animator;
    [SerializeField] private InputController _input;
    [SerializeField] private GameObject _weaponColliderObj;
    private int comboStep = 0;

    private void Update()
    {
        if(_input.attack)
        {
            Attack();
        }
    }

    private void Attack()
    {
        SecondAttack();
        FirstAttack();
    }

    private void FirstAttack()
    {
        if (comboStep == 0)
        {
            _movement.SetMovingPossibility(false);
            _animator.SetBool("isDoingCombo", false);
            _animator.SetTrigger("attack");
            comboStep++;
            _weaponColliderObj.SetActive(true);
        }
    }

    private void SecondAttack()
    {
        if (comboStep != 0)
        {
            _weaponColliderObj.SetActive(false);
            _movement.SetMovingPossibility(false);
            _animator.SetBool("isDoingCombo", true);
            _weaponColliderObj.SetActive(true);
        }
    }

    public void ResetCombo()
    {
        _weaponColliderObj.SetActive(false);
        comboStep = 0;
        _animator.Play("Idle");
        _animator.SetBool("isDoingCombo", false);
        _movement.SetMovingPossibility(true);
    }
}

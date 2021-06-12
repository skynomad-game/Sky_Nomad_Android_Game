using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCharacterController : MonoBehaviour
{

    public Vector2 facingDirection;

    public Vector2 walkingDirection;



    public Animator _animator;

    public bool isWalking;

    public bool isTalking;



    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();

        walkRight();
        StartCoroutine(WaitSomeTime(2.0f));
        walkUp();
        StartCoroutine(WaitSomeTime(2.0f));
        walkLeft();
        StartCoroutine(WaitSomeTime(2.0f));
        walkDown();
        StartCoroutine(WaitSomeTime(2.0f));
    }



   
    public void walkRight()
    {
        _animator.SetFloat("Horizontal", 1);
      
    }

    public void walkLeft()
    {
        _animator.SetFloat("Horizontal", -1);

    }

    public void walkUp()
    {
        _animator.SetFloat("Vertical", 1);

    }

    public void walkDown()
    {
        _animator.SetFloat("Vertical", -1);

    }

    public IEnumerator WaitSomeTime(float secondNum)
    {
        yield return new WaitForSeconds(secondNum);
    }


}

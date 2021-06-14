using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimNpcManager : MonoBehaviour
{
    public AnimCharacterController character;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void WalkUpAnim()
    {
        character.walkUp();
    }

    public void WalkRightAnim()
    {
        character.walkRight();
    }

    public void WalkDownAnim()
    {
        character.walkDown();
    }

    public void WalkLefAnim()
    {
        character.walkLeft();
    }

    public void Talk()
    {
        character.Talk();
    }

    public void StopWalkingUp()
    {
        character.StopWalking(new Vector2(0, 1));
        _animator.SetBool("Stop", true);

    }

    public void StopWalkingRight()
    {
        character.StopWalking(new Vector2(1, 0));
        _animator.SetBool("Stop", true);

    }

    public void StopWalkingDown()
    {
        _animator.SetBool("Stop", true);

        character.StopWalking(new Vector2(0, -1));

    }

    public void StopWalkingLeft()
    {
        character.StopWalking(new Vector2(-1, 0));
        _animator.SetBool("Stop", true);

    }

    public void StopAnimator()
    {
        character.GetComponent<Animator>().SetBool("Walking", false);
    }

   



}

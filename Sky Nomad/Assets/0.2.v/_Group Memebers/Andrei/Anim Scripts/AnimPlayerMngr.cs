using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayerMngr : MonoBehaviour
{
    public AnimCharacterController animCharacterController;

    public List<GameObject> playerCharacters;

    private int playerInt;

    private Animator _animator;

    public bool goToNextScene;


    private void Start()
    {
        playerInt = PlayerPrefs.GetInt("personajeEscogido", 0);
        playerCharacters[playerInt].SetActive(true);
        animCharacterController = playerCharacters[playerInt].GetComponent<AnimCharacterController>();
        _animator = GetComponent<Animator>();
        

    }

    public void WalkUpAnim()
    {
        animCharacterController.walkUp();
    }

    public void WalkRightAnim()
    {
        animCharacterController.walkRight();
    }

    public void WalkDownAnim()
    {
        animCharacterController.walkDown();
    }

    public void WalkLefAnim()
    {
        animCharacterController.walkLeft();
    }

    public void Talk()
    {
        animCharacterController.Talk();
    }

    public void StopWalkingUp()
    {
        animCharacterController.StopWalking(new Vector2(0, 1));
        _animator.SetBool("Stop", true);

    }

    public void StopWalkingRight()
    {
        animCharacterController.StopWalking(new Vector2(1, 0));
        _animator.SetBool("Stop", true);

    }

    public void StopWalkingDown()
    {
        _animator.SetBool("Stop", true);

        animCharacterController.StopWalking(new Vector2(0, -1));

    }

    public void StopWalkingLeft()
    {
        animCharacterController.StopWalking(new Vector2(-1, 0));
        _animator.SetBool("Stop", true);

    }

    public void StartTalking()
    {
        animCharacterController.GetComponent<Animator>().SetBool("Walking", false);
        animCharacterController.Talk();
        goToNextScene = true;
    }

  

}

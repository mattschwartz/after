using UnityEngine;
using System.Collections;
using After.Interactable;
using After.Interactable.Transitions;

public class PlayerRunTransition : Transition
{
    #region Members

    public float Speed;
    public PlayerController Player;
    public Animator PlayerAnimator;

    private bool Active;

    #endregion

    void Start()
    {
        Active = false;
    }

    public override void Read(StateType fromState, StateType toState)
    {
        Player.LockPlayer();
        PlayerAnimator.SetFloat("Velocity", 1);
        Active = true;
    }

    void Update()
    {
        if (Active) {
            Player.rigidbody2D.velocity = new Vector2(Speed, Player.rigidbody2D.velocity.y);
        }
    }

}

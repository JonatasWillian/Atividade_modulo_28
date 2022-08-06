using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ebac.StateMachine
{
    public class StateBase : MonoBehaviour
    {
        public virtual void OnStateEnter(object o = null)
        {
            Debug.Log("OnStateEnter");
        }

        public virtual void OnStateStay(object o = null)
        {
            Debug.Log("OnStateStay");
        }

        public virtual void OnStateExit(object o = null)
        {
            Debug.Log("OnStateExit");
        }
    }

    public class StateIdle : StateBase
    {
        public Animator animator;

        public string triggerIdle = "Idle";

        private void Start()
        {
            OnStateEnter();
        }

        public override void OnStateEnter(object o = null)
        {
            animator.SetTrigger(triggerIdle);
        }
    }

    public class StateWalking : StateBase
    {
        public Animator animator;

        public string triggerWalking = "Walking";

        public override void OnStateEnter(object o = null)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                animator.SetTrigger(triggerWalking);
            }
        }

        public override void OnStateExit(object o = null)
        {
        
        }
    }

    public class StateJumping : StateBase
    {
        public override void OnStateEnter(object o = null)
        {
        
        }
    }
}
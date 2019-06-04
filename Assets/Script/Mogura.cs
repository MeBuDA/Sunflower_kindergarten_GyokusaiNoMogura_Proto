//Prefabでモグラ量産できるようにするためにMoguraObjectManager.csと分けた

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoguraPosition //MoguraObjectManager.csで使う
{
    public class Mogura : MonoBehaviour
    {
        private Animator animator;
        void Awake ()
        {
            animator = this.GetComponent<Animator> ();
        }

        public void MoguraOut ()
        {
            animator.SetTrigger ("MoguraOut");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Interactable
{
    public abstract class Transition : MonoBehaviour
    {
        #region Members

        public StateType From;
        public StateType To;

        #endregion

        public abstract void Read();
    }
}

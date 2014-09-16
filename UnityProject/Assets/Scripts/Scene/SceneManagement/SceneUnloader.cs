using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Scene.SceneManagement
{
    public class SceneUnloader : MonoBehaviour
    {
        public virtual void OnSceneUnloaded()
        {
            // Does nothing by default.
        }
    }
}

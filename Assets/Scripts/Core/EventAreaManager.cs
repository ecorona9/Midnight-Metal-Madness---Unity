using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MidnightMetalMadness
{
    public class EventAreaManager : MonoBehaviour
    {
        public static EventAreaManager instance { get; private set; }

        public event Action<Transform, int> OnPlayerEntersArea;
        
        private void Awake()
        {
            instance = this;
        }

        public void AwakeCops(Transform obj, int id)
        {
            OnPlayerEntersArea?.Invoke(obj, id);
        }


    }
}

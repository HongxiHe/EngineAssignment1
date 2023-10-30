using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace testingDll2
{
    public abstract class Singleton<T> : MonoBehaviour
        where T : MonoBehaviour
    {
        static T s_instance;


        public static T Instance()
        {
            if (s_instance == null)
            {
                s_instance = FindObjectOfType<T>();

                if (s_instance == null)
                {
                    Debug.Log("set name of type");
                    GameObject instanceObject = new GameObject("Singleton", typeof(T));
                }
            }

            return s_instance; // return our new and only instanced singleton
        }

        protected virtual void Awake()
        {
            Debug.Log("awake" + gameObject.name);
            if (s_instance != null && FindObjectsOfType<T>().Length > 1)
            {
                Debug.Log("destroyed");
                Destroy(this);
            }
        }

        protected virtual void OnDestroy()
        {
            if (s_instance == this)
            {
                Debug.Log("set null");
                s_instance = null;
            }
        }
    }

}

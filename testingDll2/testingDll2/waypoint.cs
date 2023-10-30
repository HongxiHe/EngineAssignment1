using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace testingDll2
{
    [System.Serializable]
    public class waypoint
    {
        [SerializeField] public Vector3 pos;

        public void SetPos(Vector3 newPos)
        {
            pos = newPos;
        }
        public Vector3 GetPos()
        {
            return pos;
        }

        public waypoint()
        {
            pos = new Vector3(0, 0, 0);
        }
    }
}

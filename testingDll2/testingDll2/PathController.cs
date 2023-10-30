using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace testingDll2
{
    public class MovingControl : MonoBehaviour
    {
        [SerializeField]
        public PathManager _pathManager;

        List<waypoint> thePath;
        waypoint target;

        public float MoveSpeed;
        public float RotateSpeed;

        bool isSprinting;
        // Start is called before the first frame update
        void Start()
        {
            isSprinting = false;


            thePath = _pathManager.GetPath();
            if (thePath != null && thePath.Count > 0)
            {
                target = thePath[0];
            }
        }

        void rotateTowardsTarget()
        {
            float stepSize = RotateSpeed * Time.deltaTime;

            Vector3 targetDir = target.pos - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, stepSize, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
        }
        void moveForward()
        {
            float stepSize = Time.deltaTime * MoveSpeed;
            float distanceToTarget = Vector3.Distance(transform.position, target.pos);
            if (distanceToTarget < stepSize)
            {
                //you can modify here for overshooting condition
                return;
            }
            Vector3 moveDir = Vector3.forward;
            transform.Translate(moveDir * stepSize);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.anyKeyDown)
            {
                isSprinting = !isSprinting;
            }
            if (isSprinting)
            {
                rotateTowardsTarget();
                moveForward();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Change to");
            target = _pathManager.GetNextTarget();
        }

    }
}

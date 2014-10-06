using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Camera
{
    class SmoothFollow : MonoBehaviour
    {
        public GameObject target;

        void FixedUpdate()
        {
            Follow();
        }
        void Follow()
        {
            transform.position = Vector3.Slerp(
                transform.position,
                new Vector3(Mathf.Clamp(target.transform.position.x, -10, 10), Mathf.Clamp(target.transform.position.y, -10, 10), transform.position.z),
                0.075f
            );
            //transform.position = new Vector3(Mathf.Clamp(target.transform.position.x, -target.transform.position.x-3, target.transform.position.x+3)*Mathf.Sign(target.transform.position.x),
            //                                 Mathf.Clamp(target.transform.position.y, -150, 150),
            //                                 transform.position.z);
        }
    }
}

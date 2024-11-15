using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class FlyingObject : MonoBehaviour
    {
        private float velocity = 1f;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.relativeVelocity.magnitude > velocity)
            {
                SoundManager.Instance.PlayBgm("CupFall");
            }
        }
    }
}
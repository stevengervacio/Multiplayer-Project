using System;
using Unity.Netcode;
using UnityEngine;

public class NetworkTransformTest : NetworkBehaviour
{
   void Update()
   {
       if (IsServer)
       {
           // Comment out or remove this code to stop automatic movement
           // float theta = Time.time;
           // transform.position = new Vector3((float) Math.Cos(theta), 0.0f, (float) Math.Sin(theta));
       }
   }
}

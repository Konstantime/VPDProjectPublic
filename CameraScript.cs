// using System.Collections;
// using System.Collections.Generic;
// using UnityEditor;
// using UnityEngine;

// public class CameraScript : MonoBehaviour
// {
//     [SerializeField] private Transform playerTransform;
//     [SerializeField] private Transform subTransform;
//     [SerializeField] public string playerTag;
//     [SerializeField] public string subTag;
//     [SerializeField] private float movingSpeed;
//     [SerializeField] private float cameraSize;
//     [SerializeField] public float distance;

//     private void Awake()
//     {
//         if (this.playerTransform == null)
//         {
//             if (this.playerTag == "")
//             {
//                 this.playerTag = "Player";
//             }


//             this.playerTransform = GameObject.FindGameObjectWithTag(this.playerTag).transform;
//         }
//         if (subTag != "")
//             this.subTransform = GameObject.FindGameObjectWithTag(this.subTag).transform;

//         this.transform.position = new Vector3()
//         {
//             x = this.playerTransform.position.x,
//             y = this.playerTransform.position.y,
//             z = this.playerTransform.position.z - distance,
//         };
//     }

//     private void Update()
//     {

//         float dist = Vector3.Distance(playerTransform.position, this.transform.position);
//         if (subTag == "")
//         {
//             if (this.playerTransform)
//             {
//                 Vector3 target = new Vector3()
//                 {
//                     x = this.playerTransform.position.x,
//                     y = this.playerTransform.position.y,
//                     z = this.playerTransform.position.z - distance,
//                 };

//                 Vector3 pos = Vector3.Lerp(a: this.transform.position, b: target, t: dist * dist * this.movingSpeed * Time.deltaTime);
//                 this.transform.position = pos;
//             }
//         }
//         else
//         {
//             if (this.playerTransform)
//             {
//                 Vector3 target = new Vector3()
//                 {
//                     x = (this.playerTransform.position.x + this.subTransform.position.x) / 2,
//                     y = (this.playerTransform.position.y + this.subTransform.position.y) / 2,
//                     z = this.playerTransform.position.z - distance,
//                 };

//                 Vector3 pos = Vector3.Lerp(a: this.transform.position, b: target, t: 2000 * this.movingSpeed * Time.deltaTime );
//                 this.transform.position = pos;
//             }
//         }
            
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = new Vector3( player.position.x , player.position.y, transform.position.z );
    }

    void FixedUpdate()
    {
        transform.position = new Vector3( player.position.x , player.position.y, transform.position.z );
    }
}

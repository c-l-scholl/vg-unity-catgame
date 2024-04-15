// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// // [RequireComponent(typeof(Animator))]
// public class Controller : MonoBehaviour
// {

//     // Animator animator;
//     public float speed = 0.2f
//     public float rotationSpeed = 10f;
//     List<Vector2> pathToGo = new List<Vector2>();
//     bool moveFlag = false;
//     int index = 0;
//     Vector2 endPosition;
//     // Start is called before the first frame update
//     public void Initialize(List<Vector2> path)
//     {
//         pathToGo = path;
//         index = 1;
//         moveFlag = true;
//         endPosition = pathToGo[index];
//         // animator = GetComponent<Animator>();
//         // animator.SetTrigger("Walk"); => We're going to add Walk as a parameter

//     }

//     // Update is called once per frame
//     private void Update()
//     {
//        if (moveFlag) {
//         PerformMovement();
//        } 
//     }

//     private void PerformMovement() {
//         if (pathToGo.Count > index) {
//             float distanceToGo = Move();
//             if (distanceToGo < 0.05f) {
//                 index++;
//                 if (index >= pathToGo.Count) {
//                     moveFlag = false;
//                     Destroy(gameObject);
//                 }
//                 endPosition = pathToGo[index];
//             }
//         }
//     }

//     // private float Move() {
//     //     float step = speed * Time.deltaTime;

        
//     //         }
// }

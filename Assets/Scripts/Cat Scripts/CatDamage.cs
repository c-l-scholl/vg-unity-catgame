// using System.Collections;
// using UnityEngine;
// using UnityEngine.Events;

// public class CatDamage : MonoBehaviour
// {
//     public Color damageColor;

//     public Color defaultColor;

//     public UnityEvent hitEvent;

//     public void HandleCarCollision()
//     {
//         ChangeColor (damageColor);
//         StartCoroutine(ResetColorAfterDelay(0.35f));
//     }

//     private IEnumerator ResetColorAfterDelay(float delay)
//     {
//         yield return new WaitForSeconds(delay);

//         // Reset color after the delay
//         ChangeColor (defaultColor);

//         // Invoke the hit event after the delay
//         hitEvent.Invoke();
//     }

//     // private void ChangeColor(Color color)
//     // {
//     //     // Change the color of the sprite renderer
//     //     SpriteRenderer catRenderer = GetComponent<SpriteRenderer>();
//     //     catRenderer.color = color;
//     // }
// }

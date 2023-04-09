using System;
using UnityEngine;

namespace Creature.Controller
{
    [Serializable]
    public class Player : MonoBehaviour, IController
    {
        private Vector2 _direction = new();

        public Vector2 GetDirection()
        {
            return MoveWithKeys(_direction);
        }

        private Vector2 MoveWithKeys(Vector2 direction)
        {
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.y = Input.GetAxisRaw("Vertical");

            return direction;
        }
    }
}
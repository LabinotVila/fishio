using Creature.Attributes;
using Creature.Controller;
using UnityEngine;

namespace Creature
{
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(IController))]
    public class Creature : MonoBehaviour
    {
        public SoAttributes creatureAttributes;
        public int level = 1;

        private Movement _movement;

        private IController _movementController;

        private void Start()
        {
            _movementController = GetComponent<IController>();
            _movement = GetComponent<Movement>();
        }

        private void Update()
        {
            _movement.SetDirection(_movementController.GetDirection());
        }
    }
}
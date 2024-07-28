using System;
namespace Adapter
{
    public class AdapterWizard : IEnemyObject
    {
        private Wizard wizard;

        // Constructor: initializes a new instance of the Wizard
        public AdapterWizard(Wizard wizard)
        {
            this.wizard = wizard;
        }

        // Method to simulate an attack
        public void Attack()
        {
            wizard.AttackPlayer();  // Outputs: "The wizard attacks the player"
        }

        // Method to simulate speaking
        public void SayHello()
        {
            wizard.Communicate();  // Outputs: "The wizard greets you"
        }

        // Method to simulate sleeping
        public void Sleep()
        {
            wizard.Rest();  // Outputs: "The wizard rests"
        }
    }

}

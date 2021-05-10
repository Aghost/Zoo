namespace Zoo.Models
{
    public sealed class Elephant : Animal
    {
        public override void Eat() {
            Eat(50);
        }

        public override void UseEnergy() {
            UseEnergy(5);
        }
    }
}

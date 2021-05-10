namespace Zoo.Models
{
    public sealed class Lion : Animal
    {
        public override void Eat() {
            Eat(25);
        }

        public override void UseEnergy() {
            UseEnergy(10);
        }
    }
}

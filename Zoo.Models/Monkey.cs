namespace Zoo.Models
{
    public sealed class Monkey : Animal
    {
        public Monkey() : base(60) { }

        public override void Eat() {
            Eat(10);
        }

        public override void UseEnergy() {
            UseEnergy(2);
        }
    }
}

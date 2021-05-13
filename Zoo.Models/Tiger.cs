namespace Zoo.Models
{
    public class Tiger : Carnivore
    {
        public override void Eat()
        {
            Eat(25);
        }

        public override void UseEnergy()
        {
            UseEnergy(15);
        }
    }
}

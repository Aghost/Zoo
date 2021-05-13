using System;
using System.Diagnostics;

namespace Zoo.Models
{
    public abstract class Carnivore : Animal
    {
        public void Eat(Animal animal)
        {
            if (animal.GetType() == GetType())
                throw new InvalidOperationException("Cannibalism is not allowed");

            Debug.WriteLine($"{Name} the {GetType().Name} ate {animal.Name} the {animal.GetType().Name}, gained {animal.Energy} energy");
            Energy += animal.Energy;
            animal.Energy = 0;
        }
    }
}

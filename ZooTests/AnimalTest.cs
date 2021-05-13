using System;
using Xunit;
using Zoo.Models;

namespace ZooTests
{
    public class AnimalTest
    {
        [Fact]
        public void CreateAnimals()
        {
            Animal animal;

            animal = new Monkey();
            Assert.Equal(60, animal.Energy);

            animal = new Lion();
            Assert.Equal(100, animal.Energy);

            animal = new Tiger();
            Assert.Equal(100, animal.Energy);

            animal = new Elephant();
            Assert.Equal(100, animal.Energy);
        }

        [Fact]
        public void FeedAnimals()
        {
            Animal animal;

            animal = new Monkey();
            animal.Eat();
            Assert.Equal(70, animal.Energy);

            animal = new Lion();
            animal.Eat();
            Assert.Equal(125, animal.Energy);

            animal = new Tiger();
            animal.Eat();
            Assert.Equal(125, animal.Energy);

            animal = new Elephant();
            animal.Eat();
            Assert.Equal(150, animal.Energy);
        }

        [Fact]
        public void CarnivoresHunt()
        {
            Tiger tiger = new Tiger();
            Elephant elephant = new Elephant();
            Monkey monkey = new Monkey();

            // Diner.
            tiger.Eat(elephant); // Tiger is very hungry.
            Assert.Equal(200, tiger.Energy);
            Assert.Equal(0, elephant.Energy);

            // Desert.
            tiger.Eat(monkey); // And monkeys are delicious.
            Assert.Equal(260, tiger.Energy);
            Assert.Equal(0, monkey.Energy);

            // Cannibalism is not allowed but carnivores can eat other carnivores.
            Assert.Throws<InvalidOperationException>(() => tiger.Eat(new Tiger()));
            tiger.Eat(new Lion());
        }

        [Fact]
        public void UseEnergy()
        {
            Animal animal;
            
            animal = new Monkey();
            animal.UseEnergy();
            Assert.Equal(58, animal.Energy);

            animal = new Lion();
            animal.UseEnergy();
            Assert.Equal(90, animal.Energy);

            animal = new Tiger();
            animal.UseEnergy();
            Assert.Equal(85, animal.Energy);

            animal = new Elephant();
            animal.UseEnergy();
            Assert.Equal(95, animal.Energy);

            for (int i = 0; i < 18; i++)
                animal.UseEnergy();
            Assert.Equal(5, animal.Energy);

            // Energy should not go below zero.
            animal.UseEnergy();
            Assert.Equal(0, animal.Energy);
            animal.UseEnergy();
            Assert.Equal(0, animal.Energy);
        }
    }
}

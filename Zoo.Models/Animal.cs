using System.ComponentModel;
using System.Diagnostics;

namespace Zoo.Models
{
    public abstract class Animal : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int energy;

        public string DisplayName {
            get {
                return $"{Name}\n{GetType().Name}\nEnergy: {Energy}\n";
            }
        }

        public Animal() : this(100) { }

        protected Animal(int energy) {
            this.energy = energy;
        }

        public string Name { get; set; }
        
        public int Energy {
            get => energy;
            set {
                if (energy != value) {
                    energy = value;
                    // Waarom MOET PropertyChanged in de setter van een property worden aangeroepen?
                    // Als je dezelfde RaisePropertyChanged() vanuit een andere functie aanroept werkt het niet?
                    RaisePropertyChanged();
                }
            }
        }

        public abstract void Eat();
        public abstract void UseEnergy();

        protected void Eat(int energy) {
            Debug.WriteLine($"{Name} the {GetType().ToString().Split('.')[2]} ate food, gained {energy} energy");
            Energy += energy;
        }

        protected void UseEnergy(int energy) {
            Energy = Energy > energy ? Energy - energy : 0;
        }

        protected void RaisePropertyChanged() {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisplayName)));
        }
    }
}

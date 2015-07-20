namespace Balloons_Pops_game
{
    using System;

    // Class for comparing scores between two players
    public class Rating : IComparable<Rating>
    {
        // Fields
        private int value;
        private string name;

        // Constructor for adding initial values
        public Rating(int value, string name)
        {
            this.Value = value;
            this.Name = name;
        }

        // Properties
        public int Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        // CompareTo method for comparing with other 'Rating' object
        public int CompareTo(Rating other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }
}
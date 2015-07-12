namespace Balloons_Pops_game
{
    using System;

    //Class for comparing scores between two players
    public class Rating : IComparable<Rating>
    {
        //Fields
        public int value;
        public string name;

        //Constructor for adding initial values
        public Rating(int value, string name)
        {
            Value = value;
            Name = name;
        }

        //Properties
        public int Value
        {
            get
            {
                return value;
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
                return name;
            }
            set
            {
                name = value;
            }
        }

        //CompareTo method for comparing with other 'Rating' object
        public int CompareTo(Rating other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
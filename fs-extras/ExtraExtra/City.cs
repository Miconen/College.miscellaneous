using Game;

namespace Game
{
    public class City : Entity
    {
        public City(int health)
        {
            this.maxHealth = health;
            this.health = health;
            this.damage = 1;
        }

        public void Update(int round)
        {
            int damage = this.damage;
            if (round % 5 == 0) damage = 5;
            else if (round % 3 == 0) damage = 3;

            this.damage = damage;
        }
    }
}

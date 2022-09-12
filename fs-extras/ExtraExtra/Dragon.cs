using Game;

namespace Game
{
    public class Dragon : Entity
    {
        public int distance { get; set; }

        public Dragon(int health, int distance)
        {
            this.maxHealth = health;
            this.health = health;
            this.distance = distance;
            this.damage = 1;
        }
    }
}

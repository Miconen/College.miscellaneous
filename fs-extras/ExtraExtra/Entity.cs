using Game;

namespace Game
{
    public class Entity
    {
        public int maxHealth { get; set; }
        public int health { get; set; }
        public int damage { get; set; }

        public bool Alive()
        {
            return (this.health > 0) ? true : false;
        }

        public bool Dead()
        {
            return !this.Alive();
        }

        public void Attack(Entity target)
        {
            target.Damage(this.damage);
        }

        public void Damage(int damage)
        {
            this.health -= damage;
        }
    }
}

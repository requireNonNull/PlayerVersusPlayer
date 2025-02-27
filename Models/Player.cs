using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace aivftw
{
    public enum PlayerValues
    {
        MaxLevel = 80,
        MinLevel = 0,
        MaxHealth = 100,
        MinHealth = 0,
        AttackDamage = 10,
    }

    public enum PlayerType
    {
        Player,
        AI,
    }

    public class Player
    {
        Random random;

        public string Name { get; private set; }
        public double Health { get; private set; }
        public double BaseDamage { get; private set; }
        public int Level { get; private set; }
        public int Speed { get; private set; }
        public PlayerType PlayerType { get; set; }

        public Player SelectedTarget { get; private set; }
        public event EventHandler<string> InfoSent;
        public event EventHandler<bool> OnPlayerDeath;

        public bool IsAlive { get; private set; }
        public bool IsAbsorbingDamage { get; private set; }

        public Player(string name)
        {
            random = new Random();

            Name = name;
            Health = (double)PlayerValues.MaxHealth;
            BaseDamage = (double)PlayerValues.AttackDamage;
            Level = (int)PlayerValues.MinLevel;
            PlayerType = PlayerType.Player;

            SelectedTarget = null;
        }

        public void UseAbility(PlayerAbility ability)
        {
            if (SelectedTarget == null)
            {
                string debug = "SelectedTarget == null";
                Debug.WriteLine(debug);
                InfoSent?.Invoke(this, debug);
                return;
            }

            ability.Use(this, SelectedTarget);
        }

        public void SelectTarget(Player target)
        {
            if (target == null)
            {
                string debug = "Target == null";
                Debug.WriteLine(debug);
                return;
            }

            SelectedTarget = target;
        }

        public void TakeDamage(double damage, PlayerAbility playerAbility)
        {
            if (IsAbsorbingDamage)
            {
                double randomAbsorbingAmount = random.Next((int)damage);
                damage -= randomAbsorbingAmount;
                this.Health -= damage;
            }
            else
            {
                this.Health -= damage;
            }
        }

        public void SendData(string message)
        {
            InfoSent?.Invoke(this, message);
        }

        public void Heal(double heal)
        {
            this.Health += heal;
        }

        public async Task ForceShield(PlayerAbility playerAbility)
        {
            IsAbsorbingDamage = true;
            await Task.Delay(TimeSpan.FromSeconds(playerAbility.Cooldown));
            IsAbsorbingDamage = false;
        }

        public async Task ForceSpot(Player target, PlayerAbility playerAbility)
        {
            double timeInSeconds = playerAbility.Cooldown;
            double originalDamage = BaseDamage;
            double reductionPercent = 20;
            double spotStrength = originalDamage * (reductionPercent / 100);

            while (timeInSeconds > 0)
            {
                if (SelectedTarget != target)
                {
                    BaseDamage = Math.Max(originalDamage - spotStrength, 0);
                }
                else
                {
                    BaseDamage = originalDamage;
                }

                await Task.Delay(TimeSpan.FromSeconds(1));
                timeInSeconds--;
            }

            BaseDamage = originalDamage;
        }

        public void SetName(String name)
        {
            this.Name = name;
        }

        public void SetHealth(double health)
        {
            this.Health = health;
        }

        public double GetHealth()
        {
            return this.Health;
        }

        public String GetName()
        {
            return this.Name;
        }
    }
}

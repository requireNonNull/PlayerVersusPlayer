using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aivftw
{
    public enum AbilityType
    {
        Heal,
        Damage,
        Tank,
        Absorb,
    }

    public class PlayerAbility
    {

        public string Name { get; private set; }
        public double Cooldown { get; private set; }
        public double BaseStrength { get; private set; }
        public EffectTypes? EffectType { get; private set; }
        public AbilityType AbilityType { get; private set; }

        public bool isOnCooldown { get; private set; }

        public PlayerAbility(string name, double cooldown, double baseStrength, AbilityType abilityType)
        {
            Name = name;
            Cooldown = cooldown;
            BaseStrength = baseStrength;
            AbilityType = abilityType;
        }

        public async void Use(Player caster, Player target)
        {
            if (isOnCooldown)
            {
                string debug = "isOnCooldown = true";
                caster.SendData(debug);
                return;
            }

            isOnCooldown = true;
            _ = StartCooldown();

            switch (AbilityType)
            {
                case AbilityType.Heal:
                    double heal = CalculateHeal(caster, target);
                    target.Heal(heal);
                    break;

                case AbilityType.Damage:
                    double damage = CalculateDamage(caster, target);
                    target.TakeDamage(damage, this);
                    break;

                case AbilityType.Tank:
                    await target.ForceSpot(caster, this);
                    break;

                case AbilityType.Absorb:
                    await target.ForceShield(this);
                    break;
            }
        }

        private async Task StartCooldown()
        {
            await Task.Delay(TimeSpan.FromSeconds(Cooldown));
            isOnCooldown = false;
            Debug.WriteLine("isOnCooldown = false");
        }

        public double CalculateHeal(Player caster, Player target)
        {
            double finalHeal = BaseStrength + (caster.Level * 0.25);

            return finalHeal;
        }

        public double CalculateDamage(Player caster, Player target)
        {
            double finalDamage = BaseStrength + (caster.Level * 0.25);

            return finalDamage;
        }
    }
}

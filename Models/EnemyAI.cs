using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aivftw
{
    public class EnemyAI : Player
    {
        public event EventHandler<string> OnAbilityUse;

        Random random;

        public bool isAttacking;

        public EnemyAI(string name) : base(name)
        {
            PlayerType = PlayerType.AI;

            random = new Random();

            isAttacking = false;
        }
        public async Task StartAttacks(List<PlayerAbility> abilities)
        {
            isAttacking = true;

            while (isAttacking)
            {
                RandomAttack(abilities);

                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }

        public void StopAttacks()
        {
            isAttacking = false;
        }


        public void RandomAttack(List<PlayerAbility> abilities)
        {
            int randomPick = random.Next(abilities.Count);
            PlayerAbility pickedAbility = abilities[randomPick];
            if (pickedAbility != null
                && pickedAbility.AbilityType != AbilityType.Heal
                && pickedAbility.AbilityType != AbilityType.Absorb)
            {
                UseAbility(pickedAbility);
                OnAbilityUse?.Invoke(this, pickedAbility.Name);
            }
        }
    }
}

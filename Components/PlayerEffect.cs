using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerVersusPlayer
{
    public enum EffectTypes
    {
        Healing,
        Barrier,
        Slowing,
        Enrage,
    }

    public enum BuffType
    {
        Buff,
        Debuff,
    }

    public class PlayerEffect
    {
        public double Delay { get; private set; }
        public double DelaySpeed { get; private set; }
        public double Strength { get; private set; }

        public EffectTypes EffectType { get; private set; }
        public BuffType BuffType { get; private set; }

        public PlayerEffect(EffectTypes effect, BuffType buffType)
        {
            EffectType = effect;
            BuffType = buffType;

            switch (effect)
            {
                case EffectTypes.Healing:
                    Delay = 5;
                    DelaySpeed = 1;
                    Strength = 10;
                    break;

                case EffectTypes.Barrier:
                    Delay = 10;
                    DelaySpeed = 1;
                    Strength = 5;
                    break;

                case EffectTypes.Slowing:
                    Delay = 10;
                    DelaySpeed = 1;
                    Strength = 20;
                    break;

            }
        }
    }
}

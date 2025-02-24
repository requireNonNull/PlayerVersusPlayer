using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerVersusPlayer
{
    public partial class GameForm : Form
    {
        private readonly Player _PlayerOne;
        private readonly EnemyAI _EnemyAI;
        private readonly PlayerAbility _PlayerHealAbility;
        private readonly PlayerAbility _PlayerShieldAbility;
        private readonly PlayerAbility _PlayerTankAbility;
        private readonly PlayerAbility _PlayerAttackAbility;

        private readonly PlayerAbility _EnemyHealAbility;
        private readonly PlayerAbility _EnemyShieldAbility;
        private readonly PlayerAbility _EnemyTankAbility;
        private readonly PlayerAbility _EnemyAttackAbility;

        private readonly List<PlayerAbility> _playerAbilities;
        private readonly List<PlayerAbility> _enemyAbilities;

        private bool _IsAbilityTipShowing;

        private GameManager _gameManager;

        public GameForm(GameManager gameManager)
        {
            InitializeComponent();
            _gameManager = gameManager;

            _enemyAbilities = new List<PlayerAbility>
            {
                _EnemyHealAbility,
                _EnemyShieldAbility,
                _EnemyTankAbility,
                _EnemyAttackAbility
            };

            _PlayerHealAbility = new PlayerAbility
                ("Heal", 10, 10, AbilityType.Heal);
            _PlayerShieldAbility = new PlayerAbility
                ("Shield", 10, 5, AbilityType.Absorb);
            _PlayerTankAbility = new PlayerAbility
                ("Spot", 4, 10, AbilityType.Tank);
            _PlayerAttackAbility = new PlayerAbility
                ("Attack", 2, (double)PlayerValues.AttackDamage, AbilityType.Damage);

            _playerAbilities = new List<PlayerAbility>
            {
                _PlayerHealAbility,
                _PlayerShieldAbility,
                _PlayerTankAbility,
                _PlayerAttackAbility
            };

            _PlayerOne = new Player("Guest001");
            _EnemyAI = new EnemyAI("Bot001");

            _PlayerOne.SelectTarget(_EnemyAI);
            _EnemyAI.SelectTarget(_PlayerOne);

            _PlayerOne.InfoSent += this.OnDataReceived;
            _EnemyAI.OnAbilityUse += this.OnAbilityUseReceived;

            _ = UpdateUI();

            _ = _EnemyAI.StartAttacks(_enemyAbilities);
        }

        private async Task UpdateUI()
        {
            while (true)
            {
                HealthLabel.Text = Convert.ToString(Math.Round(_PlayerOne.GetHealth(), 2));
                PlayerNameLabel.Text = Convert.ToString(_PlayerOne.GetName());

                if (_PlayerOne.SelectedTarget == _PlayerOne)
                {
                    PlayerNameLabel.BorderStyle = BorderStyle.FixedSingle;
                    EnemyNameLabel.BorderStyle = BorderStyle.None;

                }
                else
                {
                    PlayerNameLabel.BorderStyle = BorderStyle.None;
                    EnemyNameLabel.BorderStyle = BorderStyle.FixedSingle;
                }

                EnemyHealthLabel.Text = Convert.ToString(_EnemyAI.GetHealth());
                EnemyNameLabel.Text = Convert.ToString(_EnemyAI.GetName());

                if (_PlayerAttackAbility.isOnCooldown)
                {
                    AttackButton.BackColor = Color.FromArgb(0, AttackButton.BackColor);
                }
                else
                {
                    AttackButton.BackColor = Color.FromArgb(255, AttackButton.BackColor);

                }

                if (_PlayerHealAbility.isOnCooldown)
                {
                    HealButton.BackColor = Color.FromArgb(0, HealButton.BackColor);
                }
                else
                {
                    HealButton.BackColor = Color.FromArgb(255, HealButton.BackColor);

                }

                if (_PlayerTankAbility.isOnCooldown)
                {
                    TankButton.BackColor = Color.FromArgb(0, TankButton.BackColor);
                }
                else
                {
                    TankButton.BackColor = Color.FromArgb(255, TankButton.BackColor);

                }
                if (_PlayerShieldAbility.isOnCooldown)
                {
                    ShieldButton.BackColor = Color.FromArgb(0, ShieldButton.BackColor);
                }
                else
                {
                    ShieldButton.BackColor = Color.FromArgb(255, ShieldButton.BackColor);

                }

                await Task.Delay(TimeSpan.FromSeconds(0.1));
            }
        }


        private async Task ShowTooltip(object sender, PlayerAbility ability, string type)
        {
            if (_IsAbilityTipShowing) return;

            Button button = (sender as Button);

            _IsAbilityTipShowing = true;
            string originalText = button.Text;
            button.Text = Convert.ToString(ability.BaseStrength) + " " + type;
            await Task.Delay(TimeSpan.FromSeconds(0.5));
            button.Text = originalText;
            _IsAbilityTipShowing = false;
        }

        private async Task FadeInInfo(Button fadeInButton, string text)
        {
            fadeInButton.Text = text;

            if (fadeInButton.Visible) return;

            fadeInButton.BackColor = Color.FromArgb(0, fadeInButton.BackColor);
            fadeInButton.Visible = true;

            for (int i = 100; i < 255; i++)
            {

                fadeInButton.BackColor = Color.FromArgb(i, fadeInButton.BackColor);
                fadeInButton.ForeColor = Color.FromArgb(i, fadeInButton.ForeColor);

                await Task.Delay(TimeSpan.FromMilliseconds(0.5));
            }

            fadeInButton.Visible = false;
        }

        private async Task FadeInAndOutInfo(Button fadeInButton, string text)
        {
            fadeInButton.Text = text;

            if (fadeInButton.Visible) return;

            fadeInButton.BackColor = Color.FromArgb(0, fadeInButton.BackColor);
            fadeInButton.Visible = true;

            for (int i = 155; i < 255; i++)
            {

                fadeInButton.BackColor = Color.FromArgb(i, fadeInButton.BackColor);
                fadeInButton.ForeColor = Color.FromArgb(i, fadeInButton.ForeColor);

                await Task.Delay(TimeSpan.FromMilliseconds(0.5));
            }

            await Task.Delay(TimeSpan.FromMilliseconds(250));

            for (int i = 155; i > 0; i--)
            {
                fadeInButton.BackColor = Color.FromArgb(i, fadeInButton.BackColor);
                fadeInButton.ForeColor = Color.FromArgb(i, fadeInButton.ForeColor);

                if (fadeInButton.Text.Length >= i)
                {
                    fadeInButton.Text = fadeInButton.Text.Remove(fadeInButton.Text.Length - 1);
                }
                await Task.Delay(TimeSpan.FromMilliseconds(0.5));
            }

            fadeInButton.Visible = false;
        }

        public void OnDataReceived(object sender, string message)
        {
            _ = FadeInAndOutInfo(InfoButton, message);
            Console.WriteLine($"Received: {message}");
        }

        public void OnAbilityUseReceived(object sender, string message)
        {
            _ = FadeInInfo(EnemyInfoButton, message);
            Console.WriteLine($"Ability used: {message}");
        }

        private void AttackButton_Click(object sender, EventArgs e)
        {
            _PlayerOne.UseAbility(_PlayerAttackAbility);
        }

        private void HealButton_Click(object sender, EventArgs e)
        {
            _PlayerOne.UseAbility(_PlayerHealAbility);
        }

        private void TankButton_Click(object sender, EventArgs e)
        {
            _PlayerOne.UseAbility(_PlayerTankAbility);
        }

        private void ShieldButton_Click(object sender, EventArgs e)
        {
            _PlayerOne.UseAbility(_PlayerShieldAbility);
        }

        private void SelectYourselfButton_Click(object sender, EventArgs e)
        {
            _PlayerOne.SelectTarget(_PlayerOne);
        }

        private void SelectEnemyButton_Click(object sender, EventArgs e)
        {
            _PlayerOne.SelectTarget(_EnemyAI);
        }

        private async void AttackButton_MouseHover(object sender, EventArgs e)
        {
            await ShowTooltip(sender, _PlayerAttackAbility, "Damage");
        }
        private async void HealButton_MouseHoverAsync(object sender, EventArgs e)
        {
            await ShowTooltip(sender, _PlayerHealAbility, "Heal");
        }

        private async void TankButton_MouseHover(object sender, EventArgs e)
        {
            await ShowTooltip(sender, _PlayerTankAbility, "Force");

        }

        private async void ShieldButton_MouseHover(object sender, EventArgs e)
        {
            await ShowTooltip(sender, _PlayerShieldAbility, "Absorbing");
        }
    }
}

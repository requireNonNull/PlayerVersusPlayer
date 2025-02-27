using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static aivftw.Utils.Animations;

namespace aivftw
{
    public partial class OnlineGameForm : Form
    {

        private Player _player;
        private Player _opponent;
        private EnemyAI _enemyAI;

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
        private Random _random;

        public OnlineGameForm(GameManager gameManager, NetworkManager networkManager)
        {
            InitializeComponent();
            if (gameManager == null)
            {
                Debug.WriteLine("GameManager is null!");
            }
            _gameManager = gameManager;
            _random = new Random();

            _EnemyHealAbility = new PlayerAbility
                ("Heal", 10, 10, AbilityType.Heal);
            _EnemyShieldAbility = new PlayerAbility
                ("Shield", 10, 5, AbilityType.Absorb);
            _EnemyTankAbility = new PlayerAbility
                ("Spot", 4, 10, AbilityType.Tank);
            _EnemyAttackAbility = new PlayerAbility
                ("Attack", 2, (double)PlayerValues.AttackDamage, AbilityType.Damage);


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

            SetupMatch();

            _ = UpdateUI();

            this.FormClosing += OnlineGameForm_FormClosing;

        }

        private void OnlineGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit();
        }

        private void SetupMatch()
        {
            _gameManager.InitPlayer("Player");
            _gameManager.InitOpponent("Opponent");

            _player = _gameManager.GetPlayer();
            _opponent = _gameManager.GetOpponent();
            _enemyAI = new EnemyAI("Bot");

            _enemyAI.OnAbilityUse += this.OnAbilityUseReceived;
            _player.InfoSent += this.OnDataReceived;

            _enemyAI.SelectTarget(_player);

            _ = _enemyAI.StartAttacks(_enemyAbilities);

        }

        private async Task UpdateUI()
        {
            while (_player == null || _enemyAI == null)
            {
                await Task.Delay(100);
            }

            while (true)
            {
                HealthLabel.Text = Convert.ToString(Math.Round(_player.GetHealth(), 2));
                PlayerNameLabel.Text = Convert.ToString(_player.GetName());

                if (_player.SelectedTarget == _player)
                {
                    PlayerNameLabel.BorderStyle = BorderStyle.FixedSingle;
                    EnemyNameLabel.BorderStyle = BorderStyle.None;

                }
                else
                {
                    PlayerNameLabel.BorderStyle = BorderStyle.None;
                    EnemyNameLabel.BorderStyle = BorderStyle.FixedSingle;
                }

                EnemyHealthLabel.Text = Convert.ToString(_enemyAI.GetHealth());
                EnemyNameLabel.Text = Convert.ToString(_enemyAI.GetName());

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

        public void OnDataReceived(object sender, string message)
        {
            _ = FadeInAndOut(InfoButton, message);
            Console.WriteLine($"Received: {message}");
        }

        public void OnAbilityUseReceived(object sender, string message)
        {
            _ = FadeIn(EnemyInfoButton, message);
            Console.WriteLine($"Ability used: {message}");
        }

        private void AttackButton_Click(object sender, EventArgs e)
        {
            _player.UseAbility(_PlayerAttackAbility);
        }

        private void HealButton_Click(object sender, EventArgs e)
        {
            _player.UseAbility(_PlayerHealAbility);
        }

        private void TankButton_Click(object sender, EventArgs e)
        {
            _player.UseAbility(_PlayerTankAbility);
        }

        private void ShieldButton_Click(object sender, EventArgs e)
        {
            _player.UseAbility(_PlayerShieldAbility);
        }

        private void SelectYourselfButton_Click(object sender, EventArgs e)
        {
            _player.SelectTarget(_player);
        }

        private void SelectEnemyButton_Click(object sender, EventArgs e)
        {
            _player.SelectTarget(_enemyAI);
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;

namespace RPG
{
    public partial class RPG : Form
    {
        private Player _player;

        public RPG()
        {
            InitializeComponent();

            _player = new Player(10, 10, 20, 0, 1);


            lblHitPoints.Text = _player.CurrentHitPoints.ToString();
            lblGold.Text = _player.Gold.ToString();
            lblExperience.Text = _player.ExperiencePoints.ToString();
            lblLevel.Text = _player.Level.ToString();
        }

        // Тези по-долу са auto-generated. Не са част от проекта и ще ги махнем, но ги оставете за сега.
        private void RPG_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

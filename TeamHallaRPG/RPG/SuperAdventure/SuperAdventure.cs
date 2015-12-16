namespace RPG
{
    using Engine;
    using System.Windows.Forms;

    public partial class SuperAdventure : Form
    {
        private Player _player;

        public SuperAdventure()
        {
            InitializeComponent();

            _player = new Player(10, 10, 20, 0, 1);

            lblHitPoints.Text = _player.CurrentHitPoints.ToString();
            lblGold.Text = _player.Gold.ToString();
            lblExperience.Text = _player.ExperiencePoints.ToString();
            lblLevel.Text = _player.Level.ToString();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SuperAdventure
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "SuperAdventure";
            this.Load += new System.EventHandler(this.SuperAdventure_Load);
            this.ResumeLayout(false);

        }

        private void SuperAdventure_Load(object sender, System.EventArgs e)
        {

        }
    }
}

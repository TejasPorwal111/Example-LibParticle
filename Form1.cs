using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibParticle;

namespace particles
{
    public partial class Form1 : Form
    {
        private ParticleSystem ps;
        public Form1()
        {
            InitializeComponent();
            BackColor = ParticleSystem.SetDarkBackground(3);
            DoubleBuffered = true;
            Color[] mycolors = new Color[] { Color.Blue, Color.Red, Color.Yellow, Color.Aquamarine , Color.Chartreuse };
            if (mycolors != null && mycolors.Length > 0 && mycolors[0] != null)
            {
                // Instantiate ParticleSystem with valid parameters
                ps = new ParticleSystem(Particle.Shapetype.Mixed, 8f, 10, 100, 5, mycolors, Particle.glowtype.Shadow, ClientSize.Width, ClientSize.Height);
            }
            else
            {
                // Handle invalid mycolors array (log error, throw exception, etc.)
                Console.WriteLine("Invalid color array detected.");
            }
            ps.OnParticlesUpdated += ParticleSystem_OnParticlesUpdated;

        }
        private void ParticleSystem_OnParticlesUpdated(object sender, EventArgs e)
        {
            Invalidate(); // Trigger form redraw on particle updates
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;

            foreach (Particle particle in ps.particles)
            {
                particle.Draw(graphics);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ps.Start(); // Start the particle system
        }
    }
}

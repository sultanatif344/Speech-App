using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;

namespace SpeechApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SpeechSynthesizer ss = new SpeechSynthesizer();

        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();

        private void button1_Click(object sender, EventArgs e)
        {
            ss.Volume = trackBar1.Value;

            ss.Speak(this.textBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sre.SetInputToDefaultAudioDevice();

            DictationGrammar dg=new DictationGrammar();

            sre.LoadGrammar(dg);

            RecognitionResult r=sre.Recognize();

            this.textBox1.Text = r.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ss.Speak("Exiting");
            Application.Exit();
        }
    }
}

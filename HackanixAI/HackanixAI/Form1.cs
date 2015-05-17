using DataBaseConnection;
using stringOperations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HackanixAI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = null;
            textBox3.Text = null;
            label1.Text = "Voice recognition";
            string UserInput = textBox1.Text;
            if (UserInput.Equals(""))
            {
                MessageBox.Show("Please enter some issue");
                return;
            }
            SQLConn sqc = new SQLConn("datasource=localhost;port=3306;username=root;password=1234");
            StringProcessor sp = new StringProcessor(UserInput,ref textBox2,ref textBox3);
            sp.matchTheCase();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine engineSpeech = new SpeechRecognitionEngine();
            Grammar gram = new DictationGrammar();
            engineSpeech.LoadGrammar(gram);
            try
            {
                engineSpeech.SetInputToDefaultAudioDevice();
                RecognitionResult result = engineSpeech.Recognize();
                label1.Text = result.Text;
                textBox1.Text = result.Text;
                button1_Click(new Object(),new EventArgs());
            }
            catch (Exception)
            {
                //Do nothing
            }
            finally
            {
                engineSpeech.UnloadAllGrammars();
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(sender, e);
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace sirutacsvfiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics g;
        Pen pen0 = new Pen(Color.Silver, 1);

        //x
        //x min
        //20.03
        //x max
        //29.65

        //y
        //43.66
        //y min
        //48.25
        //y max



        //   !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //for creating the map only set makeingthemap  = 1;
        //pentru creare harta modificati in makeingthemap  = 1;
        public int makeingthemap = 0;
        
        void drawRS(float x1, float y1, float x2, float y2) {
                                                
            g.DrawRectangle(pen0, x1 , y1 , x2-x1 , y2-y1);
        }

            static int xy = 100;
            static float dy = (float)(48.25 - 43.66);
            static float dx = (float)(29.65 - 20.03);

            static float hy = (float)(dy / 2);
            static float hx = (float)(dx / 2);
            static int ys = 4700;
            static int xs = 2020;
        
        // work 
        // convert y to inversul lui iar x ramane 
        //functioenaza foar pentru latitudini si longitudine de la 0 + 180 x  si 0 + 180 y 
        // y trebuie convertit pentru a nu arata imaginea inversata cu susul in jos
        // se gasesc min si max y si x
        // se gasesc jumatate din x si din y
        // se aplica pentru y formula de mai jos

        //asta este foarte inceata
        //necesita ceva lucru si prelucrare paralela

        void drawLatLong(float x, float y, float r, TextBox t)
        {
            //filtrare date dupa nr de locuitori
            if (r >= 0 && r <=50000000)
            {

            if (y < hy) {
                y = y + (hy - y)+ y ;
            }
            else if (y > hy)
            {
                y = y - (y - hy)- y;
            }


           // Text = (x * xy - xs).ToString();
           // Text += " : ";
           // Text += (y * xy + ys).ToString();
           
                g.DrawEllipse(pen0, x * xy - xs, y * xy + ys, 2 + r / 20000, 2 + r / 20000);
                g.DrawString(t.Text, Font, new SolidBrush(Color.Black), x * xy - xs, y * xy + ys);

                //add to txtXMLResult textbox as xml result

                //genereaza codul xml 
                //pareta asat e prea inceata si necesita ceva lucru
                //necesita prelucrare paralela
                //si salvarea rezultatelor intrun stream de iesire si salvare
                //la fiecare ciclu
                //vezi fisierul xml atasat proeictului xmlFile1.xml unde puteit insera apoi codul generat in locul care trebuie
                //xmlfile1.xml e de fapt un fieiser svg nu uita sa schimbi terminatia din xml in svg
    // txtXMLResult.Text += "\r\n";
    // txtXMLResult.Text += " <circle ";
    // txtXMLResult.Text +=" cx=\""+(x * xy - xs).ToString()+"\"";
    // txtXMLResult.Text += " cy=\"" + (y * xy + ys).ToString() + "\"";
    // txtXMLResult.Text +=" r=\"0.5\"";
    // txtXMLResult.Text += " id=\"" + t.Text + "\"";
    // txtXMLResult.Text +=" />";
    // Refresh();
    // txtXMLResult.Text += "\r\n";
    // txtXMLResult.Text +=" <text";
    // txtXMLResult.Text +=" x=\""+x.ToString()+"\"";
    // txtXMLResult.Text += " y=\"" + y.ToString() + "\"";
    // txtXMLResult.Text += ">" + t.Text + " " + x.ToString() + " "  +y.ToString() + "</text>";
            }
        }

        //daca folositi siruta atunci utilizati ';' daca utilizati orase atunci ','
        FileStream f;
        int i = 0;
        string[] lines;
        string lcurenta;
        public void removeSigns()
        {
            char v;
            //string v;
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                textBox1.Select(i, 1);
                v = Convert.ToChar(textBox1.SelectedText);
                //v = textBox1.SelectedText;
                //if (v == "\"")
                    if (v == '\"')
                {
                    //do's not work
                    textBox1.Select(i, 1);
                    //textBox1.Text.Replace(v, "");
                    textBox1.Text.Replace(v, ' ');
                }
            }
        }

        public void splitfraze()
        {
            int px = 0;
            int cx = 0;
            char v;
            //pentru siruta sau pentru orase
            //char p = ';';
            char p = ',';
            List<string> cuvinte = new List<string>();
            removeSigns();
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                px = cx;
                textBox1.Select(i, 1);
                v = Convert.ToChar(textBox1.SelectedText);

                if (v == p )
                {
                    cx = i;
                    textBox1.Select(px + 1, cx - px - 1);

                    //pentru siruta sau pentru orase
                    //if (textBox1.SelectedText != ";")
                    if (textBox1.SelectedText != ",")
                    {
                        cuvinte.Add(textBox1.SelectedText);
                        textBox1.Select(cx + 1, 1);
                    }
                }
            }
        for (int j = 0; j < cuvinte.Count; j++)
            {
                Text += cuvinte[j] + " : ";
                if (j == 0) { textBox2.Text = cuvinte[j]; }
                else if (j == 1) { textBox3.Text = cuvinte[j]; }
                else if (j == 2) { textBox4.Text = cuvinte[j]; }
                else if (j == 3) { textBox5.Text = cuvinte[j]; }
                else if (j == 4) { textBox6.Text = cuvinte[j]; }
                else if (j == 5) { textBox7.Text = cuvinte[j]; }
                else if (j == 6) { textBox8.Text = cuvinte[j]; }
                else if (j == 7) { textBox9.Text = cuvinte[j]; }
                else if (j == 8) { textBox10.Text = cuvinte[j]; }
                else if (j == 9) { textBox11.Text = cuvinte[j]; }
                else if (j == 10) { textBox12.Text = cuvinte[j]; }
                else if (j == 11) { textBox13.Text = cuvinte[j]; }
                else if (j == 12) { textBox14.Text = cuvinte[j]; }
                else if (j == 13) { textBox15.Text = cuvinte[j]; }
                else if (j == 14) { textBox16.Text = cuvinte[j]; }
                else if (j == 15) { textBox17.Text = cuvinte[j]; }
                else if (j == 16) { textBox18.Text = cuvinte[j]; }
                else if (j == 17) { textBox19.Text = cuvinte[j]; }
            }

        try
        {
            if (makeingthemap == 1)
            {
                drawLatLong(float.Parse(textBox2.Text), float.Parse(textBox3.Text), float.Parse(textBox7.Text), textBox4);
            }
        }
        catch { }
       

        }

        public void find1strow()
        {
            int px = 0;
            int cx = 0;
            char v;
            //pentru siruta sau pentru orase
            //char p = ';';
            char p = ',';

            List<string> cuvinte = new List<string>();
            removeSigns();
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                px = cx;
                textBox1.Select(i, 1);
                v = Convert.ToChar(textBox1.SelectedText);
                
                
                if (v == p )
                {
                    cx = i;
                    textBox1.Select(px + 1, cx - px - 1);

                    //pentru siruta sau pentru orase
                    //if (textBox1.SelectedText != ";")
                        if (textBox1.SelectedText != ",")
                    {
                        cuvinte.Add(textBox1.SelectedText);
                        textBox1.Select(cx + 1, 1);
                    }
                }
            }
            for (int j = 0; j < cuvinte.Count; j++)
            {
                Text += cuvinte[j] + " : ";
                if (j == 0) { label1.Text = cuvinte[j]; }
                else if (j == 1) { label2.Text = cuvinte[j]; }
                else if (j == 2) { label3.Text = cuvinte[j]; }
                else if (j == 3) { label4.Text = cuvinte[j]; }
                else if (j == 4) { label5.Text = cuvinte[j]; }
                else if (j == 5) { label6.Text = cuvinte[j]; }
                else if (j == 6) { label7.Text = cuvinte[j]; }
                else if (j == 7) { label8.Text = cuvinte[j]; }
                else if (j == 8) { label9.Text = cuvinte[j]; }
                else if (j == 9) { label10.Text = cuvinte[j]; }
                else if (j == 10) { label11.Text = cuvinte[j]; }
                else if (j == 11) { label12.Text = cuvinte[j]; }
                else if (j == 12) { label13.Text = cuvinte[j]; }
                else if (j == 13) { label14.Text = cuvinte[j]; }
                else if (j == 14) { label15.Text = cuvinte[j]; }
                else if (j == 15) { label16.Text = cuvinte[j]; }
                else if (j == 16) { label17.Text = cuvinte[j]; }
                else if (j == 17) { label17.Text = cuvinte[j]; }
            }
        }



            


        private void Form1_Load(object sender, EventArgs e)
        {
            //f = new FileStream("siruta//siruta.csv", FileMode.Open);
             //lines = File.ReadAllLines("siruta//siruta.csv");
            //lines = File.ReadAllLines("siruta//sirutaWithOutSigns.csv");
            lines = File.ReadAllLines("siruta//oraseWithOutSigns.csv");

            Text = lines.Length.ToString(); //16979
            lcurenta = lines[i];
            textBox1.Text = ";" + lcurenta + ";";
            find1strow();
            splitfraze();

            if (makeingthemap == 0) { button9.Text = "makingthemap==0"; button9.Enabled = false; }
            g = pictureBox1.CreateGraphics();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            i = 0;
            lcurenta = lines[i];
            textBox1.Text = ";" + lcurenta+";";
            splitfraze();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            i = lines.Length - 1;
            lcurenta = lines[i];
            textBox1.Text = ";" + lcurenta + ";";
            splitfraze();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (i > 0)
            {
                i--;
                lcurenta = lines[i];
                textBox1.Text = ";" + lcurenta + ";";
                splitfraze();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            if (i < lines.Length-1)
            {
                i++;
                lcurenta = lines[i];
                textBox1.Text = ";" + lcurenta + ";";
                splitfraze();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            splitfraze();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            removeSigns();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bool gasit = false;

            while (gasit == false && textBox20.Text !="INTRODUCETI LOCALITATEA")
            {
                if (i < lines.Length - 1)
                {
                    i++;
                    lcurenta = lines[i];
                    textBox1.Text = ";" + lcurenta + ";";

                    splitfraze();
                }

                if (textBox3.Text == textBox20.Text)
                {
                    gasit = true;
                }
                
                Refresh();
                Thread.Sleep(1);
            };
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
                bool gasit = false;

                while (gasit == false && textBox20.Text != "INTRODUCETI NUMARUL JUDETULUI")
            {
                if (i < lines.Length - 1)
                {
                    i++;
                    lcurenta = lines[i];
                    textBox1.Text = ";" + lcurenta + ";";

                    splitfraze();
                }

                if (textBox5.Text == textBox21.Text)
                {
                    gasit = true;
                }
                
                Refresh();
                Thread.Sleep(1);
            };
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //schimba loopx pentru a vedea mai multe sau mai putine localitati
            int loopx = 1;
            for (int t = 0; t < lines.Length; t += loopx)
            {
                Text = "";
                if (i < lines.Length - 1 - loopx)
                {
                    i += loopx;
                    lcurenta = lines[i];
                    textBox1.Text = ";" + lcurenta + ";";
                    splitfraze();
                }
            }
            Thread.Sleep(10000);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int loopx = 1;
            float min = 100;
            float curr = 0;
            for (int t = 0; t < lines.Length; t += loopx)
            {
                Text = "";
                if (i < lines.Length - 1 - loopx)
                {
                    i += loopx;
                    lcurenta = lines[i];
                    textBox1.Text = ";" + lcurenta + ";";
                    splitfraze();
                }
                curr = float.Parse(textBox2.Text);
                if (min > curr) {
                    min = curr;
                }

            }
            button10.Text = min.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int loopx = 1;
            float max = 0;
            float curr = 0;
            for (int t = 0; t < lines.Length; t += loopx)
            {
                Text = "";
                if (i < lines.Length - 1 - loopx)
                {
                    i += loopx;
                    lcurenta = lines[i];
                    textBox1.Text = ";" + lcurenta + ";";
                    splitfraze();
                }
                curr = float.Parse(textBox2.Text);
                if (max < curr)
                {
                    max = curr;
                }

            }
            button11.Text = max.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int loopx = 1;
            float min = 100;
            float curr = 0;
            for (int t = 0; t < lines.Length; t += loopx)
            {
                Text = "";
                if (i < lines.Length - 1 - loopx)
                {
                    i += loopx;
                    lcurenta = lines[i];
                    textBox1.Text = ";" + lcurenta + ";";
                    splitfraze();
                }
                curr = float.Parse(textBox3.Text);
                if (min > curr)
                {
                    min = curr;
                }

            }
            button13.Text = min.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int loopx = 1;
            float max = 0;
            float curr = 0;
            for (int t = 0; t < lines.Length; t += loopx)
            {
                Text = "";
                if (i < lines.Length - 1 - loopx)
                {
                    i += loopx;
                    lcurenta = lines[i];
                    textBox1.Text = ";" + lcurenta + ";";
                    splitfraze();
                }
                curr = float.Parse(textBox3.Text);
                if (max < curr)
                {
                    max = curr;
                }

            }
            button12.Text = max.ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            drawRS(20.03f, 43.66f, 29.65f, 48.25f);
        }


        public int ismd = 0;


        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            ismd = 0;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ismd == 1)
            {
                pictureBox1.Left += e.X;
                pictureBox1.Top += e.Y;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ismd = 1;
        }
    }
}

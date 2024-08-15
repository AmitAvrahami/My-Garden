using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Garden
{

    public partial class start_game : Form
    {
        int ticks = 300;
        int points = 0;
        int countPlants = 0, Xpose = 0, Ypos = 0;
        int clickED = 0, clickBT = 0, clickFl = 0;  // משתני בקרה ללחצנים לדעת אם הם לחוצים או לא
        garden myG = new garden();
        bool clickPause = true, movepic = false;



        
        
        private void button7_Click(object sender, EventArgs e)
        {
            int a, index;
            if (btrd1.Checked) { a = 1; }
            else { a = 2; }
            index = myG.searchPlanetByName("beauti tree" + a.ToString());
            if (index < 0 || index >= myG.CountOfPlants()) { MessageBox.Show("Eror"); }
            else if (0 <= index && myG.getPlant(index).Planet_is_Ready() == true)
            {
                if (myG.getPlant(index).pick() == false) { MessageBox.Show("you already picked"); }
                else {
                    MessageBox.Show("the Leaves picked Succeeded");
                    switch (a)
                    {
                        case 1: { planet3.Image = imageList3.Images[5]; break; }
                        case 2: { planet6.Image = imageList3.Images[5]; break; }
                    }
                }
            }
            else { MessageBox.Show("the Tree need more water"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {//מחיקת פרח
            int a, index;
            if (f1rd.Checked) { a = 1; }
            else { a = 2; }
            index = myG.searchPlanetByName("flower" + a.ToString());
            if (index < 0 || index >= myG.CountOfPlants()) { MessageBox.Show("Eror"); }
            else if (0 <= index && myG.getPlant(index).checkIfCanPick() == true)
            {
                myG.getPlant(index).photos = 0;
                myG.destroyPlanet(index);
                countPlants--;


                { MessageBox.Show("the delete Succeeded"); }
                switch (a)
                {
                    case 1: { planet1.Image = null; break; }
                    case 2: { planet4.Image = null; break; }
                }

                points += 25;


            }

            else { MessageBox.Show("the Flower need more water|| you didn't picked the Petels||you didnt prune"); }
            if (countPlants == 0)
            {
                clickBT = clickFl = clickED = 0 ;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {//קטיפת פירות
            int a, index;
            if (ed1rd.Checked) { a = 1; }
            else { a = 2; }
            index = myG.searchPlanetByName("edible tree" + a.ToString());
            if (index < 0 || index >= myG.CountOfPlants()) { MessageBox.Show("Eror"); }
            else if (0 <= index && myG.getPlant(index).Planet_is_Ready() == true)
            {
                if (myG.getPlant(index).pick() == false) { MessageBox.Show("you already picked"); }
                else
                {
                    MessageBox.Show("the picked Succeeded");
                    switch (a)
                    {
                        case 1: { planet2.Image = imageList1.Images[6]; break; }
                        case 2: { planet5.Image = imageList1.Images[6]; break; }
                    }
                    points += 50;
                }
            }
            else { MessageBox.Show("the Tree need more water"); }
        }

        private void saveButtom_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();// + "..\\myModels";
            saveFileDialog1.Filter = "model files (*.mdl)|*.mdl|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    //!!!!
                    formatter.Serialize(stream, myG);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {//גזימת ענפים
            int a, index;
            if (ed1rd.Checked) { a = 1; }
            else { a = 2; }
            index = myG.searchPlanetByName("edible tree" + a.ToString());
            if (index < 0 || index >= myG.CountOfPlants()) { MessageBox.Show("Eror"); }
            else if (0 <= index && myG.getPlant(index).Planet_is_Ready() == true)
            {
                if (myG.getPlant(index).prune() == false) { MessageBox.Show("you already pruned"); }
                else
                {
                    MessageBox.Show("the prune Succeeded");
                    switch (a)
                    {
                        case 1: { planet2.Image = imageList1.Images[5]; break; }
                        case 2: { planet5.Image = imageList1.Images[5]; break; }
                    }
                    points += 25;
                }
            }
            else { MessageBox.Show("the Tree need more water"); }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            {//גזימת ענפים
                int a, index;
                if (btrd1.Checked) { a = 1; }
                else { a = 2; }
                index = myG.searchPlanetByName("beauti tree" + a.ToString());
                if (index < 0 || index >= myG.CountOfPlants()) { MessageBox.Show("Eror"); }
                else if (0 <= index && myG.getPlant(index).Planet_is_Ready() == true)
                {
                    if (myG.getPlant(index).prune() == false) { MessageBox.Show("you already pruned"); }
                    else
                    {
                        MessageBox.Show("the prune Succeeded");
                        switch (a)
                        {
                            case 1: { planet3.Image = imageList3.Images[6]; break; }
                            case 2: { planet6.Image = imageList3.Images[6]; break; }
                        }
                        points += 25;
                    }
                }
                else { MessageBox.Show("the Tree need more water"); }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int a, index;
            if (f1rd.Checked) { a = 1; }
            else { a = 2; }
            index = myG.searchPlanetByName("flower" + a.ToString());
            if (index < 0 || index >= myG.CountOfPlants()) { MessageBox.Show("Eror"); }
            else if (0 <= index && myG.getPlant(index).Planet_is_Ready() == true)
            {
                if (myG.getPlant(index).prune() == false) { MessageBox.Show("you already pruned"); }
                else
                {
                    MessageBox.Show("the prune Succeeded");
                    switch (a)
                    {
                        case 1: { planet1.Image = imageList2.Images[5]; break; }
                        case 2: { planet4.Image = imageList2.Images[5]; break; }
                    }
                    points += 25;
                }
            }
            else { MessageBox.Show("the Flower need more water"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int a, index;
            if (ed1rd.Checked) { a = 1; }
            else { a = 2; }
            index = myG.searchPlanetByName("edible tree" + a.ToString());
            if (index < 0 || index >= myG.CountOfPlants()) { MessageBox.Show("Eror"); }
            else if (0 <= index && myG.getPlant(index).checkIfCanDestroy() == true)
            {
                myG.getPlant(index).photos = 0;
                myG.destroyPlanet(index);
                countPlants--;

                { MessageBox.Show("the delete Succeeded"); }
                switch (a)
                {
                    case 1: { planet2.Image = null; break; }
                    case 2: { planet5.Image = null; break; }
                }


            }

            else { MessageBox.Show("the Tree need more water|| you didn't picked the fruits||you didnt prune"); }
            if (countPlants == 0)
            {
                clickBT = clickFl = clickED = 0;
                
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int a, index;
            if (btrd1.Checked) { a = 1; }
            else { a = 2; }
            index = myG.searchPlanetByName("beauti tree" + a.ToString());
            if (index < 0 || index >= myG.CountOfPlants()) { MessageBox.Show("Eror"); }
            else if (0 <= index && myG.getPlant(index).checkIfCanDestroy() == true)
            {
                myG.getPlant(index).photos = 0;
                myG.destroyPlanet(index);

                MessageBox.Show("the delete Succeeded");
                countPlants--;
                switch (a)
                {
                    case 1: { planet3.Image = null; break; }
                    case 2: { planet6.Image = null; break; }
                }
            }
            else { MessageBox.Show("the Tree need more water|| you didn't picked the leaves||you didnt prune"); }
            if (countPlants == 0)
            {
                clickBT = clickFl = clickED = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label12.Text = points.ToString();
            timer1.Start();
            ticks--;
            label11.Text = ticks.ToString();
            if (ticks == 0)
            {
                label11.Text = "Done";
                timer1.Stop();
                MessageBox.Show("Your score is " + points.ToString());
            }
        }



        private void label11_VisibleChanged(object sender, EventArgs e)
        {
            timer1.Start();
            timer1_Tick(sender, e);

        }


        private void label12_VisibleChanged(object sender, EventArgs e)
        {
            label12.Text = points.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (clickPause == true)
            {
                timer1.Stop();
                clickPause = false;
            }
            else { timer1.Start(); clickPause = true; }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();// + "..\\myModels";
            openFileDialog1.Filter = "model files (*.mdl)|*.mdl|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Stream stream = File.Open(openFileDialog1.FileName, FileMode.Open);
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                //!!!!
                myG = (garden)binaryFormatter.Deserialize(stream);
                planet1.Invalidate();
                loadGame();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {//קטיפת עלי כותרת
            int a, index;
            if (f1rd.Checked) { a = 1; }
            else { a = 2; }
            index = myG.searchPlanetByName("flower" + a.ToString());
            if (index < 0 || index >= myG.CountOfPlants()) { MessageBox.Show("Eror"); }
            else if (0 <= index && myG.getPlant(index).Planet_is_Ready() == true)
            {
                if (myG.getPlant(index).pick() == false) { MessageBox.Show("you already picked"); }
                else
                {
                    MessageBox.Show("the picked Succeeded");
                    switch (a)
                    {
                        case 1: { planet1.Image = imageList2.Images[7]; break; }
                        case 2: { planet4.Image = imageList2.Images[7]; break; }
                    }
                }
            }
            else { MessageBox.Show("the Flower need more water"); }
        }



        public start_game()
        {
            InitializeComponent();
        }
        //*
        private void CET_Click(object sender, EventArgs e)
        {

            if (clickED == 0)
            {
                myG.addPlanet(0);
                planet2.Image = imageList1.Images[0];
                countPlants++;
            }
            if (clickED == 1)
            {
                myG.addPlanet(0);
                planet5.Image = imageList1.Images[0];
                countPlants++;
            }
            if (clickED > 1)
                MessageBox.Show("The trees are not ready.\n please water them");
            clickED++;

        }

        private void CBT_Click(object sender, EventArgs e)
        {
            if (clickBT == 0)
            {
                myG.addPlanet(1);
                planet3.Image = imageList3.Images[0];
                countPlants++;
            }
            if (clickBT == 1)
            {
                myG.addPlanet(1);
                planet6.Image = imageList3.Images[0];
                countPlants++;
            }
            if (clickBT > 1)
                MessageBox.Show("The trees are not ready.\n please water them");
            clickBT++;
        }

        private void CF_Click(object sender, EventArgs e)
        {


            if (clickFl == 0)
            {
               
                myG.addPlanet(2);
                planet1.Image = imageList2.Images[0];
                countPlants++;
            }
            if (clickFl == 1)
            {
                
                myG.addPlanet(2);
                planet4.Image = imageList2.Images[0];
                countPlants++;
            }
            if (clickFl > 1)
                MessageBox.Show("The Flowers are not ready.\n please water them");
            clickFl++;


        }

        private void planet1_MouseUp(object sender, MouseEventArgs e)
        {
            movepic = false;
        }

        private void planet2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Xpose = e.X;
                Ypos = e.Y;
                movepic = true;
            }
        }

        private void planet2_MouseUp(object sender, MouseEventArgs e)
        {
            movepic = false;
        }

        private void planet2_MouseMove(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            if (movepic && c != null)
            {
                c.Top = e.Y + c.Top - Ypos;
                c.Left = e.X + c.Left - Xpose;
            }
        }

        private void planet3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Xpose = e.X;
                Ypos = e.Y;
                movepic = true;
            }
        }

        private void planet3_MouseMove(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            if (movepic && c != null)
            {
                c.Top = e.Y + c.Top - Ypos;
                c.Left = e.X + c.Left - Xpose;
            }
        }

        private void planet3_MouseUp(object sender, MouseEventArgs e)
        {
            movepic = false;
        }

        private void planet4_MouseUp(object sender, MouseEventArgs e)
        {
            movepic = false;
        }

        private void planet4_MouseMove(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            if (movepic && c != null)
            {
                c.Top = e.Y + c.Top - Ypos;
                c.Left = e.X + c.Left - Xpose;
            }
        }

        private void planet4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Xpose = e.X;
                Ypos = e.Y;
                movepic = true;
            }
        }

        private void planet5_MouseUp(object sender, MouseEventArgs e)
        {
            movepic = false;
        }

        private void planet5_MouseMove(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            if (movepic && c != null)
            {
                c.Top = e.Y + c.Top - Ypos;
                c.Left = e.X + c.Left - Xpose;
            }
        }

        private void planet5_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                Xpose = e.X;
                Ypos = e.Y;
                movepic = true;
            }
        }

        private void planet6_MouseUp(object sender, MouseEventArgs e)
        {
            movepic = false;
        }

        private void planet6_MouseMove(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            if (movepic && c != null)
            {
                c.Top = e.Y + c.Top - Ypos;
                c.Left = e.X + c.Left - Xpose;
            }
        }

        private void planet6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Xpose = e.X;
                Ypos = e.Y;
                movepic = true;
            }
        }

        private void planet1_MouseMove(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            if(movepic&&c!=null)
            {
                c.Top = e.Y + c.Top - Ypos;
                c.Left = e.X + c.Left - Xpose;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {//כפתור השקיה
            if (planetChoise.Text.Length == 0)
            {
                MessageBox.Show("you didnt Enter a plant");
            }
            else
            {
                int a = int.Parse(planetChoise.Text), index;
                string name;
                if (edrd.Checked) { name = "edible tree"; }
                else if (btrd.Checked) { name = "beauti tree"; }
                else { name = "flower"; }
                name = name + a.ToString();
                index = myG.searchPlanetByName(name);//האינדקס שבמערך הצמחים
                if (index < 0 || index >= myG.CountOfPlants()) { MessageBox.Show("Eror"); }
                else if (0 <= index && myG.getPlant(index).Planet_is_Ready() == true)
                {
                    myG.getPlant(index).make_Plant_Ready();
                    MessageBox.Show(name + " has a full amount of water");
                    return;
                }

                else
                {
                    myG.getPlant(index).Water_a_plant();
                    switch (name)
                    {
                        case "flower1": { planet1.Image = imageList2.Images[++myG.getPlant(index).photos]; break; }
                        case "flower2": { planet4.Image = imageList2.Images[++myG.getPlant(index).photos]; break; }
                        case "edible tree1": { planet2.Image = imageList1.Images[++myG.getPlant(index).photos]; break; }
                        case "edible tree2": { planet5.Image = imageList1.Images[++myG.getPlant(index).photos]; break; }
                        case "beauti tree1": { planet3.Image = imageList3.Images[++myG.getPlant(index).photos]; break; }
                        case "beauti tree2": { planet6.Image = imageList3.Images[++myG.getPlant(index).photos]; break; }
                    }
                    if (myG.getPlant(index).Planet_is_Ready() == true) { myG.getPlant(index).make_Plant_Ready(); }
                    return;
                }
                MessageBox.Show("you choose wrong planet");
            }
        }

        private void planet1_MouseDown(object sender, MouseEventArgs e)
        {
           
            if(e.Button == MouseButtons.Left)
            {
                Xpose = e.X;
                Ypos = e.Y;
                movepic = true;
            }
        }

        private void loadGame()
        {
            for (int i = 0; i < myG.CountOfPlants(); i++)
            {
                PictureBox photo = new PictureBox();
                switch(myG.getPlant(i).Name)
                {
                    case "flower1": { planet1.Image = imageList2.Images[myG.getPlant(i).photos];photo = planet1; break; }
                    case "flower2": { planet4.Image = imageList2.Images[myG.getPlant(i).photos]; photo = planet4; break; }
                    case "edible tree1": { planet2.Image = imageList1.Images[myG.getPlant(i).photos]; photo = planet2; break; }
                    case "edible tree2": { planet5.Image = imageList1.Images[myG.getPlant(i).photos]; photo = planet5; break; }
                    case "beauti tree1": { planet3.Image = imageList3.Images[myG.getPlant(i).photos]; photo = planet3; break; }
                    case "beauti tree2": { planet6.Image = imageList3.Images[myG.getPlant(i).photos]; photo = planet6; break; }
                }
            }
        }


    

    private void start_game_Load(object sender, EventArgs e)
        {
           
        }
    }
}
    


    



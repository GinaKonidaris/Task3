using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace POEGADE18013130
{
    public partial class Form1 : Form
    {       
        Map map = new Map(20, 20, 20);
        const int START_X = 20;
        const int START_Y = 20;
        const int SPACING = 10;
        const int SIZE = 20;
        Random r = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayMap();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            txtInfo.Text = DateTime.Now.ToLongTimeString();
            //updatemap{} dipsplay map
            // txtturn.text = ( ++turn).Tostring();
        }
        private void DisplayMap()
        {   //clears the groupbox
            groupbox1.Controls.Clear();


            foreach (Unit u in map.Units)
            {
                if (u.GetType() == typeof(MeleeUnit))
                {
                    int start_x; int start_y;
                    start_x = groupbox1.Location.X;
                    start_y = groupbox1.Location.Y;
                    MeleeUnit n = (MeleeUnit)u;
                    Button b = new Button();
                    b.Size = new Size(SIZE, SIZE);
                    b.Location = new Point(START_X + (n.xpos * SIZE), START_Y + (n.ypos * SIZE));
                    b.Text = n.symbol;
                    //the colour of each type of unit
                    if (n.Team == 1)
                    {
                        b.ForeColor = Color.Red;
                    }
                    else 
                    {
                        b.ForeColor = Color.Green;
                    }               
                    if (n.Isdead()) //if the type of unit is dead it will change the unit to black
                    {
                        b.ForeColor = Color.Black;
                    }

                    b.Click += new EventHandler(button_click);
                    groupbox1.Controls.Add(b);

                    this.Controls.Add(b);
                }
                 else if ( u.GetType()== typeof(Building)) // displays building
                {
                    int start_x; int start_y;
                    start_x = groupbox1.Location.X;
                    start_y = groupbox1.Location.Y;
                    MeleeUnit n = (MeleeUnit)u;
                    Button b = new Button();
                    b.Size = new Size(SIZE, SIZE);
                    b.Location = new Point(START_X + (n.xpos * SIZE), START_Y + (n.ypos * SIZE));
                    b.Text = n.symbol;
                    b.ForeColor = Color.Beige;
                }
            }

        }
        private void UpdateMap() //updates map to move units
        {
            foreach (Unit u in map.Units)
            {
                if (u.GetType() == typeof(MeleeUnit))
                {
                    MeleeUnit n = (MeleeUnit)u;
                    if (n.health < 25)
                    {
                        switch (r.Next(0, 4)) // changes the direction of unit
                        {
                            case 0: ((MeleeUnit)u).Move(Direction.North); break;
                            case 1: ((MeleeUnit)u).Move(Direction.East); break;
                            case 2: ((MeleeUnit)u).Move(Direction.South); break;
                            case 3: ((MeleeUnit)u).Move(Direction.West); break;
                        }
                    }
                    else // In combat or moving towards
                    {
                        bool inCombat = false;

                        foreach (Unit e in map.Units)
                        {
                            if (u.Inranged(e)) // Incombat
                            {
                                u.Combat(e);
                            }
                        }
                        if (!inCombat)
                        {
                            Unit c = u.Closest(map.Units);

                            u.Move(n.DirectionTo(c));

                        }


                    }
                }
            }
        }
     

        private void timer2_Tick(object sender, EventArgs e)//timer shows the duration of the game
        {
            UpdateMap();
            DisplayMap();
        }
        private void button_click(object sender, EventArgs e)// the location of the unit is show
        {
            int x = ((Button)sender).Location.X / SIZE - groupbox1.Location.X / SIZE;
            int y = ((Button)sender).Location.Y / SIZE - groupbox1.Location.Y / SIZE;
            foreach (MeleeUnit u in map.Units) 
            {

                if (u.GetType() == typeof(MeleeUnit))
                {
                    MeleeUnit n = (MeleeUnit)u;
                    if (n.xpos == x && n.ypos == y)
                    {
                        txtInfo.Text = "Button CLicked at" + n.Tostring();
                    }

                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)// this button loads previous saved files for users
        {
            Form1 b = new Form1();

            BinaryFormatter bf = new BinaryFormatter();
            FileStream fsin = new FileStream("Map.dat", FileMode.Open, FileAccess.Read, FileShare.None);
            try
            {
                using (fsin)
                {
                    b = (Form1)bf.Deserialize(fsin);
                    txtInfo.Text = b.ToString();
                    MessageBox.Show("Map Info Loaded");
                }
            }
            catch
            {
                MessageBox.Show("Error occurred");
            }
        }

        private void btnSave_Click(object sender, EventArgs e) //Saves the information of the map for the user to use later
        {
            Form1 b = new   Form1();
            b.Name = txtInfo.Text;
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fsout = new FileStream("Map.dat", FileMode.Create, FileAccess.Write, FileShare.None);

            try
            {
                using (fsout)
                {
                    bf.Serialize(fsout, b);
                    MessageBox.Show("Map Info Saved");
                }
            }
            catch
            {
                MessageBox.Show("Error occurred");
            }
        }
        //El0ei
    }
}

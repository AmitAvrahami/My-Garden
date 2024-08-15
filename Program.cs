using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Garden
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }
    }
    [Serializable]
    public abstract class Planet
    {
        int _countWater;
        int _maxWater;
        int _cm;
        string _name;
        protected int _photonum;


        public Planet() { }


        public abstract bool checkIfCanDestroy();
        public abstract bool checkIfCanPick();
        public abstract bool pick();


        public int Cm
        {
            set { this._cm = value; }
            get { return this._cm; }
        }

        public int photos
        {
            set { this._photonum = value; }
            get { return this._photonum; }
        }



        public string Name
        {
            set { this._name = value; }
            get { return this._name; }
        }


        public int CountWater
        {
            set { this._countWater = value; }
            get { return this._countWater; }
        }

        public int MaxWater
        {
            set { this._maxWater = value; }
            get { return this._maxWater; }
        }

        public void restorPhotos()
        {
            this.photos = 0;
        }
        public abstract bool prune();
        public abstract void make_Plant_Ready();
        public bool Planet_is_Ready()
        {
            if (this._countWater >= this._maxWater) //אנחנו רוצים אנימציה של השקייה וגם הקפצת הודעה בהתאם
            {
                return true;
            }
            return false;
        }

        public void Water_a_plant()
        {
            if (this.Planet_is_Ready() == false)
            {
                this._countWater++;
                this.Cm = this._cm++;
            }
            else this.make_Plant_Ready();
        }


    }


    [Serializable]
    public abstract class Trees : Planet
    {
        protected bool _branch;


        public bool Branch
        {
            set { this._branch = value; }
            get { return this._branch; }
        }

        public override void make_Plant_Ready()
        {
            this.Branch = true;
        }

        public override bool prune()

        {
            if (this.Planet_is_Ready() == true&&this.Branch==true)
            {
                this.Branch = false;
                this.Cm = this.Cm--;
                return true;
            }
            else
                return false;
        }

    }


    [Serializable]
    public class Edible_tree : Trees
    {
        bool _fruits;

        public bool fruit
        {
            set { this._fruits = value; }
            get { return this._fruits; }
        }



        public Edible_tree(string name, int max_water, bool Fruit ,int photo)
        {
            this.Name = name;
            this.MaxWater = max_water;
            this.fruit = Fruit;
            this._photonum = 0;
        }

        ~Edible_tree() { }

        public override bool pick() // כאן נרצה לקטוף את הפירות ולמכור אותם 
        {
            if (this.fruit == true)
            {
                this.fruit = false;//נקטף
                return true;
            }
            return false;
        }

        public override void make_Plant_Ready()
        {
            this.fruit = true;
            this.Branch = true;
        }

        public override bool checkIfCanDestroy()
        {
            if (this.Planet_is_Ready() == true && this.Branch == false && this.fruit == false)
                return true;
            return false;
        }

        public override bool checkIfCanPick()
        {
            if (this.fruit == false)
            {
                return true;
            }
            return false;
        }

    }

    [Serializable]
    public class beautiTree : Trees
    {
        bool _leaves;



        public bool leaves
        {
            set { this._leaves = value; }
            get { return this._leaves; }
        }



        ~beautiTree() { }

        public beautiTree(string name, int max_water, bool Leaves,int photo)
        {
            this.Name = name;
            this.MaxWater = max_water;
            this.leaves = Leaves;
            this.photos = 0;
        }


        public override void make_Plant_Ready()
        {
            this._leaves = true;
            this.Branch = true;
        }
        public override bool checkIfCanPick()
        {
            if (this.leaves == false)
            {
                return true;
            }
            return false;
        }

        public override bool checkIfCanDestroy()
        {
            if (this.Branch == false && this.leaves == false && this.Planet_is_Ready() == true)
                return true;
            return false;
        }

        public override  bool pick()
        {
            if (this._leaves == true)
            {
                this.leaves = false;
                return true;
            }
            return false;
        }
    }
    [Serializable]
    public class flower : Planet
    {
        bool _thorns;
        bool _Petals;

        public bool thorns
        {

            set { this._thorns = value; }
            get { return this._thorns; }
        }



        public override bool prune()
        {
            if (this.thorns == true) // כאן נרצה לגנוז את הקוצים של הפרח 
            {
                this.thorns = false;
                return true;//נגזם
            }
            return false;
        }
        public flower(string name, int max_water,int photos)
        {
            this.Name = name; // comboBox
            this.MaxWater = max_water;
            this.thorns = false;
            this._Petals = false;
            this.Cm = 0;
            this.photos = 0;

        }

        public override bool checkIfCanDestroy()
        {
            if (this.Planet_is_Ready() == true && this._Petals == false && this._thorns == false)
                return true;
            return false;
        }

        public override void make_Plant_Ready()
        {
            this._thorns = true;
            this._Petals = true;
        }

        public override bool pick()
        {
            if (this._Petals == true && this.checkIfCanPick()==false) // כאן נרצה לגנוז את עלי הכותרת של הפרח 
            {
                this._Petals = false;
                return true;//נגזם
            }
            return false;
        }
        public bool chekIfCanPrune()
        {
            //בודק האם הפרח מוכן(הושקה מספיק) וגם אם הקוצים נגזמו
            if ( this._thorns == false)
            {
                return true;
            }
            return false;
        }

        public override bool checkIfCanPick()
        {//בודק האם הפרח מוכן(הושקה מספיק) וגם אם עלי הכותרת נגזמו
            if (this.Planet_is_Ready() == true && this._Petals == false)
            {
                return true;
            }
            return false;
        }
    }
    [Serializable]
    public class garden
    {
        List<Planet> _planetsArr;
        int iEdible = 0, iFlower = 0, iBeauti = 0;
        public garden()
        {
            this._planetsArr = new List<Planet>(0);
        }



        public void addPlanet(int choise)
        {
            int size = _planetsArr.Count;
            List<Planet> newarr = new List<Planet>(size + 1);
            for (int i = 0; i < this._planetsArr.Count; i++)
            {
                newarr.Add(this._planetsArr[i]);
            }
            for (int i = 0; i < this._planetsArr.Count; i++)
            {
                this._planetsArr.RemoveAt(i);
            }
            this._planetsArr = newarr;
            switch (choise)
            {
                case 0:
                    {
                        if (iEdible >= 2)
                            iEdible = 0;
                        iEdible++;
                        this._planetsArr.Add(new Edible_tree("edible tree"+iEdible.ToString(), 7, false,0)); 
                        break;
                    }
                case 1:
                    {
                        if (iBeauti >= 2)
                            iBeauti = 0;
                        iBeauti++;
                        this._planetsArr.Add(new beautiTree("beauti tree"+iBeauti.ToString(), 4, false,0)); break;
                        
                   
                    }
                case 2:
                    {
                        if (iFlower >= 2)
                            iFlower = 0;
                        iFlower++;
                        this._planetsArr.Add(new flower("flower"+iFlower.ToString(), 6,0)); break;
                    }
            }
        }

        public int CountOfPlants()
        {
            return this._planetsArr.Count;
        }

        public Planet getPlant(int index)
        {
            return this._planetsArr[index];
        }

        public int searchPlanetByName(string name)
        {
            for (int i = 0; i < this._planetsArr.Count; i++)
            {
                if (this._planetsArr[i].Name == name)
                {
                    return i;
                }
            }
            return -1;
        }
                

        public void destroyPlanet(int index)
        {
            this._planetsArr.RemoveAt(index);
        }

    }
}



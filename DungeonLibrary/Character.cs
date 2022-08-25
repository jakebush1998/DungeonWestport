namespace DungeonLibrary
{
    //abstract means it can only be inherited from; you cannot create one.
    public abstract class Character
    {
        //Funny  - Fields
        private int _life;
        private int _maxLife;
        private string _name;
        private int _hitChance;
        private int _block;


        //People - Properties (props)
        public int MaxLife
        {
            get { return _maxLife; }
            set { _maxLife = value; }
        }
        //Alternative shortcut, only if we don't have business rules
        //public int MaxLife { get; set; }
        public int Life
        {
            get { return _life; }
            set
            {
                //Business rule: Life should not be MORE than MaxLife
                if (value <= MaxLife)
                {
                    //good to go
                    _life = value;
                }//end if
                else
                {
                    _life = MaxLife;
                }//end else
            }//end set
        }//end Life prop
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        public int HitChance
        {
            get { return _hitChance; }
            set { _hitChance = value; }
        }


        public int Block
        {
            get { return _block; }
            set { _block = value; }
        }

        //Collect - Constructors (ctors)
        //1 fully qualified constructor
        public Character(string name, int hitChance, int block, int maxLife, int life)
        {
            //Property = Parameter
            //Pascal = camelCase
            MaxLife = maxLife;
            Life = life;
            Name = name;
            HitChance = hitChance;
            Block = block;
        }
        public Character()
        {

        }
        //Monkeys - Methods
        //ToString() override
        public override string ToString()
        {
            return string.Format("----- {0}--------\n" +
                "Life: {1} of {2}\nHit Chance: {3}%\n" +
                "Block: {4}",
                Name,
                Life,
                MaxLife,
                HitChance,
                Block);
        }

        public virtual int CalcBlock()
        {
            //This basic version just returns block, but this
            //will give us the option to do something different
            //in child classes.
            return Block;
        }//end CalcBlock
        public virtual int CalcHitChance()
        {
            return HitChance;
        }//end CalcHitChance
        public virtual int CalcDamage()
        {
            return 0;
            //starting this with just returning 0. We will
            //override the method in Monster and Player.
        }//end CalcDamage

    }
}
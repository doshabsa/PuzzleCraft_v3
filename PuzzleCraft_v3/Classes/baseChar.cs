using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static PuzzleCraft_v3.Classes.Player;

namespace PuzzleCraft_v3.Classes
{
    public class BaseChar
    {
        #region Properties/Fields
        protected bool isDead;
        public Token Token;
        public static List<BaseChar> CharacterList = new();
        public static List<Token> TokenList = new();
        public static Main? MainForm;
        public int Speed;
        protected int HP;
        public int Health
        {
            get { return HP; }
            set
            {
                if (value < 0) HP = 0;
                else if (HP == 0) isDead = true;
                else HP = value;
            }
        }
        public Point GetLocation { get { return Token.Location; } }
        public Size GetDimensions { get { return Token.Size; } }
        public bool IsDead { get { return isDead; } }
        #endregion

        #region Constructors
        static BaseChar()
        {
            System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();
            t1.Interval = 100;
            t1.Tick += T1_Tick;
            t1.Enabled = true;
        }

        public BaseChar(Bitmap pic, Point loc, Size size)
        {
            Token = new(pic, loc, size);
            MainForm?.Controls.Add(Token);
            TokenList.Add(Token);            
        }

        ~BaseChar()
        {

        }
        #endregion

        private static void T1_Tick(object? sender, EventArgs e)
        {
            foreach (BaseChar c in CharacterList)
                c.Move();

            try
            {
                if (CharacterList.Count >= 2)
                {
                    for (int i = 0; i < CharacterList.Count; i++)
                        for (int j = i; j < CharacterList.Count; j++)
                            if (i != j)
                                if (CrashTest(CharacterList[i], CharacterList[j]))
                                {
                                    CharacterList[i].AdvancedCollision(CharacterList[j]);
                                    CharacterList[j].AdvancedCollision(CharacterList[i]);
                                }
                }
            }
            catch
            {

            }
        }

        #region Movement/Collision
        protected virtual void Move()
        {
            //Movement for regular monster tokens
            //Player movement is overriden
        }

        private static bool CrashTest(BaseChar One, BaseChar Two)
        {
            if (One.Token.Left + One.Token.Width < Two.Token.Left) return false;
            if (Two.Token.Left + Two.Token.Width < One.Token.Left) return false;
            if (One.Token.Top + One.Token.Height < Two.Token.Top) return false;
            if (Two.Token.Top + Two.Token.Height < One.Token.Top) return false;
            return true;
        }

        public void AdvancedCollision(BaseChar otherGuy)
        {  
            if (isDead)
            {
                MainForm?.Controls.Remove(Token);
                Token.Dispose();
                CharacterList.Remove(this);
            }
        }
        #endregion
    }
}

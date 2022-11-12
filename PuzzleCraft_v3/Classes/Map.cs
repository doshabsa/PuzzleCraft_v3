using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleCraft_v3.Classes
{
    internal static class Map
    {
        #region Properties/Fields/Delegates
        //public delegate void SetupMap();
        //public static event SetupMap UpdateMapBackdrop;

        private static List<Image> ListMaps = new();
        private static Random rnd = new();
        #endregion

        #region Constructiors
        static Map()
        {            
            CreateMapList();
            BaseChar.MainForm.BackgroundImage = ListMaps[rnd.Next(0, ListMaps.Count)];
        }
        #endregion

        #region Methods
        private static void CreateMapList()
        {
            if(ListMaps.Count != 0)
                ListMaps.Clear();
            switch(rnd.Next(0, 3))
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }
        #endregion
    }
}

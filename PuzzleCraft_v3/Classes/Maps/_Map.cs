using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleCraft_v3.Classes.Maps
{
     /*
     May add fences/obstacles to maps in the future
     */

    static class _Map
    {
        public static List<Image> MapList = new();
        private static Random rnd = new Random();

        static _Map()
        {
            Main.MainForm.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public static void Fetch()
        {
            if (MapList.Count != 0)
                MapList.Clear();

            switch (rnd.Next(0,5))
            {
                case 0:
                    MapList.Add((Bitmap)Resource1.map_00);
                    MapList.Add((Bitmap)Resource1.map_01);
                    break;
                case 1:
                    MapList.Add((Bitmap)Resource1.map_10);
                    MapList.Add((Bitmap)Resource1.map_11);
                    break;
                case 2:
                    MapList.Add((Bitmap)Resource1.map_20);
                    MapList.Add((Bitmap)Resource1.map_21);
                    break;
                case 3:
                    MapList.Add((Bitmap)Resource1.map_30);
                    MapList.Add((Bitmap)Resource1.map_31);
                    break;
                case 4:
                    MapList.Add((Bitmap)Resource1.map_40);
                    MapList.Add((Bitmap)Resource1.map_41);
                    break;
            }
            Main.MainForm.BackgroundImage = MapList[0];
        }
    }
}
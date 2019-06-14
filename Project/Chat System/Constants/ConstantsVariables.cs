using System;
using System.Collections.Generic;
using System.Text;

using BinarySoftCo.ChatSystem.DataLayer;

namespace ConstantsVariables
{
    public class Constants
    {
        public const int ServerPort = 2324;
    }

    public static class Variables
    {
        private static BaseData baseData = new BaseData();
        public static BaseData BaseData
        {
            get { return baseData; }
        }
    }
}

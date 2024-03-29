﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DespinaCoffeeShop.Helpers
{
    public class Utulity
    {
        public static string GetPath(string root, params string[] folders)
        {
            string resultPath = root;
            foreach (string folder in folders)
            {
                resultPath = Path.Combine(resultPath, folder);
            }
            return resultPath;
        }
    }
}

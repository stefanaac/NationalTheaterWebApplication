﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Factory
{
    public abstract class Creator
    {
        public abstract IFileWriter getWriter();
    }
}

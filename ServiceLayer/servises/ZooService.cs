using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.servises
{
    class ZooService
    {

        private readonly ZooContext _ctx;
        public ZooService(ZooContext ctx)
        {
            _ctx = ctx;
        }


    }
}

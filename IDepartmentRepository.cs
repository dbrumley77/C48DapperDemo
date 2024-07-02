﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C48DapperDEmo
{
    internal interface IDepartmentRepository
    {

        public IEnumerable<Department> GetAllDepartments(); //Stubbed out method

        public void InsertDepartment(string newDepartmentName);

    }



}

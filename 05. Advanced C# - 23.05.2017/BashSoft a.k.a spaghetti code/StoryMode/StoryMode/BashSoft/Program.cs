﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    public class Program
    {
        public static void Main()
        {
            Tester tester = new Tester();
            IOManager ioManager = new IOManager();
            StudentsRepository repo = new StudentsRepository(new RepositoryFilter(), new RepositorySorter());

            CommandInterpreter currentInterpreter = new CommandInterpreter(tester, repo, ioManager);
            InputReader reader = new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}

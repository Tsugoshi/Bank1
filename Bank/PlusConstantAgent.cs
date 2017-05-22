﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Bank
{
    class PlusConstantAgent : BankServer
    {
        new private float AccountStatus { get; set; }
        int i=0;
        bool lockToken = false;
        public override void Update()
        {
            lockToken = false;
            Program._BankServers[0].mutex.WaitOne();

            //lock(Program._BankServers[0])

            {
                i++;
                AccountStatus = Program._BankServers[0].AccountStatus;
                AccountStatus += 50;
                Program._BankServers[0].AccountStatus = AccountStatus;
                Console.WriteLine("Plus Constant Agent Account Status=" + AccountStatus);
                if (i == 9999) { HasFinished = true; }
            }
            Program._BankServers[0].mutex.ReleaseMutex();
        }

    }
}

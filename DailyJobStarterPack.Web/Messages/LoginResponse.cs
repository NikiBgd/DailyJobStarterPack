using DailyJobStarterPack.DataBaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DailyJobStarterPack.Messages
{
    public class LoginResponse
    {
        public UserProfile UserProfile { get; set; }

        public int Status { get; set; }
    }
}
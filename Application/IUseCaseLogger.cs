﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface IUseCaseLogger
    {
        void Log(UseCaseLog log);
    }

    public class UseCaseLog
    {
        public string User { get; set; }

        public string UseCaseName { get; set; }

        public object UseCaseData { get; set; }
    }
}

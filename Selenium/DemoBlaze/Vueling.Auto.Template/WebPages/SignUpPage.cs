﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onededios.Selenium.SetUp;
using Onededios.Selenium.WebPages.Base;

namespace Onededios.Selenium.WebPages.DemoBlaze
{
    public class SignUpPage : CommonPage
    {
        public SignUpPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();
    }
}

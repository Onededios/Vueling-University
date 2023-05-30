using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Auto.Template.SetUp;
using Vueling.Auto.Template.WebPages.Base;

namespace Onededios.Testing.WebPages
{
    public class AboutPage : CommonPage
    {
        public AboutPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();
    }
}

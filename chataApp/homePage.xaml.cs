using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace chataApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class homePage : TabbedPage
    {
        public homePage()
        {
            InitializeComponent();
        }
    }
}
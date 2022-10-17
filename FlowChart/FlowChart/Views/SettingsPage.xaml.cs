using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowChart.ViewModels;
using FlowChart.Views.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlowChart.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : BaseContentPage<SettingsViewModel>
    {
        public SettingsPage(SettingsViewModel vm) : base(vm)
        {
            InitializeComponent();
        }
    }
}
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvTeploobmen.Client.Models
{
    public class GasRecordViewModel: ReactiveObject
    {
        // ctor на класс из БД
        private string _name;
        private bool _isNotUsed = true;

        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }

        public bool IsNotUsed
        {
            get => _isNotUsed;
            set => this.RaiseAndSetIfChanged(ref _isNotUsed, value);
        }
    }
}

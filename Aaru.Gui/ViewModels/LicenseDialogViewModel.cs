﻿using System.IO;
using System.Reactive;
using System.Reflection;
using Aaru.Gui.Views;
using ReactiveUI;

namespace Aaru.Gui.ViewModels
{
    public class LicenseDialogViewModel : ViewModelBase
    {
        readonly LicenseDialog _view;
        string                 _versionText;

        public LicenseDialogViewModel(LicenseDialog view)
        {
            _view        = view;
            CloseCommand = ReactiveCommand.Create(ExecuteCloseCommand);

            using(Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Aaru.Gui.LICENSE"))
                using(var reader = new StreamReader(stream))
                {
                    LicenseText = reader.ReadToEnd();
                }
        }

        public string                      Title        => "Aaru's license";
        public string                      CloseLabel   => "Close";
        public string                      LicenseText  { get; }
        public ReactiveCommand<Unit, Unit> CloseCommand { get; }

        void ExecuteCloseCommand() => _view.Close();
    }
}
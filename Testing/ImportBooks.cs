using eBookManager.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static eBookManager.Helper.ExtensionMethods;
using static System.Math;

namespace Testing
{
    public partial class ImportBooks : Form
    {
        private string _jsonPath;
        private List<StorageSpace> _spaces; 
        private enum _storageSpaceSelection 
        { 
            New = -9999,
            NoSelection = -1 
        }

        public ImportBooks()
        {
            InitializeComponent();
            _jsonPath = Path.Combine(Application.StartupPath, "bookData.txt");

        }
    }
}
